using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public class UsuarioCRUDCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProriver;

        public UsuarioCRUDCompleto(DbTeste dbTeste)
        {
            _serviceProriver = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD Usuário (Create)")]
        [Trait("CRUD", "UserEntity")]
        public async Task ShouldInsertUser()
        {
            using (var context = _serviceProriver.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registerCreated = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registerCreated);
                Assert.Equal(_entity.Email, _registerCreated.Email);
                Assert.Equal(_entity.Name, _registerCreated.Name);
                Assert.False(_registerCreated.Id == Guid.Empty);
            }
        }
    }
}
