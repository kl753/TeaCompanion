/*Service user implementation
 * Layer for abstracting business logic.
 * Orchestrates calls to repository methods.
 * Helps decouple controllers from data access logic.
 */
using AutoMapper;
using BCrypt.Net;
using Org.BouncyCastle.Asn1.Mozilla;
using TeaAPI.DTOs;
using TeaAPI.Models;
using TeaAPI.Repositories;

namespace TeaAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto?>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            //Check if the username and email already exists
            var existingUserByUsername = await _userRepository.GetUserByUserameAsync(createUserDto.Username);
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists.");
            }

            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(createUserDto.Email);
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("Email already exists.");
            }

            var user = _mapper.Map<User>(createUserDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            await _userRepository.CreateUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return null; // User not found
            }

            //Only update fields that are provided in the DTO
            if (!string.IsNullOrEmpty(updateUserDto.Username))
            {
                //Check if new username is already taken
                var userWithNewUsername = await _userRepository.GetUserByUserameAsync(updateUserDto.Username);
                if (userWithNewUsername != null && userWithNewUsername.Id != id)
                {
                    throw new ArgumentException("Username already exists.");
                }
                existingUser.Username = updateUserDto.Username;
            }
            if (!string.IsNullOrEmpty(updateUserDto.Email))
            {
                //Check if new email is already taken
                var userWithNewEmail = await _userRepository.GetUserByEmailAsync(updateUserDto.Email);
                if (userWithNewEmail != null && userWithNewEmail.Id != id)
                {
                    throw new ArgumentException("Email already exists.");
                }
                existingUser.Email = updateUserDto.Email;
            }

            existingUser.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateUserAsync(existingUser);
            await _userRepository.SaveChangesAsync();
            return _mapper.Map<UserDto>(existingUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userToDelete = await _userRepository.GetUserByIdAsync(id);
            if (userToDelete == null)
            {
                return false; // User not found
            }
            await _userRepository.DeleteUserAsync(userToDelete);
            return await _userRepository.SaveChangesAsync();
        }

        public Task<UserDto?> GetUserByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto?> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}