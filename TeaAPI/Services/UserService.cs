/*Service user implementation
 * Layer for abstracting business logic.
 * Orchestrates calls to repository methods.
 * Helps decouple controllers from data access logic.
 */
using AutoMapper;
using BCrypt.Net;
using TeaAPI.DTOs;
using TeaAPI.Models;
using TeaAPI.Repositories;

namespace TeaAPI.Services
{
    public class UserService : IUserService
    {
    }
}