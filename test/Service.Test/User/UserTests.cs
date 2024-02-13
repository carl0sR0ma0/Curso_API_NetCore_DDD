using Domain.DTOs.User;
using Faker;

namespace Service.Test.User
{
    public class UserTests
    {
        public static string NameUser { get; set; } = string.Empty;
        public static string EmailUser { get; set; } = string.Empty;
        public static string NameUserUpdated { get; set; } = string.Empty;
        public static string EmailUserUpdated { get; set; } = string.Empty;
        public static Guid IdUser { get; set; }
        public List<UserDTO> listUserDTO { get; set; } = new List<UserDTO>();
        public UserDTO userDTO { get; set; }
        public UserCreateDTO userCreateDTO { get; set; }
        public UserCreateResultDTO userCreateResultDTO { get; set; }
        public UserUpdateDTO userUpdateDTO { get; set; }
        public UserUpdateResultDTO userUpdateResultDTO { get; set; }

        public UserTests()
        {
            IdUser = Guid.NewGuid();
            NameUser = Name.FullName();
            EmailUser = Internet.Email();
            NameUserUpdated = Name.FullName();
            EmailUserUpdated = Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = Name.FullName(),
                    Email = Internet.Email()
                };
                listUserDTO.Add(dto);
            }

            userDTO = new UserDTO
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser
            };

            userCreateDTO = new UserCreateDTO()
            {
                Name = NameUser,
                Email = EmailUser
            };

            userCreateResultDTO = new UserCreateResultDTO()
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                CreateAt = DateTime.UtcNow
            };

            userUpdateDTO = new UserUpdateDTO()
            {
                Id = IdUser,
                Name = NameUserUpdated,
                Email = EmailUserUpdated
            };

            userUpdateResultDTO = new UserUpdateResultDTO()
            {
                Id = IdUser,
                Name = NameUserUpdated,
                Email = EmailUserUpdated,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
