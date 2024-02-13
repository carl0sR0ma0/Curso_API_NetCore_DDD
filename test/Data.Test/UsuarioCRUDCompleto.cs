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

        [Fact(DisplayName = "CRUD Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task ShouldCRUDUser()
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

                _entity.Name = Faker.Name.First();
                var _registerUpdated = await _repository.UpdateAsync(_entity);
                Assert.Equal(_entity.Email, _registerUpdated.Email);
                Assert.Equal(_entity.Name, _registerUpdated.Name);

                var _registerExist = await _repository.ExistAsync(_registerUpdated.Id);
                Assert.True(_registerExist);

                var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.Email, _registerSelected.Email);
                Assert.Equal(_registerUpdated.Name, _registerSelected.Name);

                var _registerAll = await _repository.SelectAsync();
                Assert.NotNull(_registerAll);
                Assert.True(_registerAll.Count() > 1);

                var _deleted = await _repository.DeleteAsync(_registerUpdated.Id);
                Assert.True(_deleted);

                var _userStandard = await _repository.FindByLogin("user.adm@mfrinfo.com");
                Assert.NotNull(_userStandard);
                Assert.Equal("user.adm@mfrinfo.com", _userStandard.Email);
                Assert.Equal("Administrator", _userStandard.Name);
            }
        }
    }
}
