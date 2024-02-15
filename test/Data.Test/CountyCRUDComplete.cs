using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Faker;

namespace Data.Test
{
    public class CountyCRUDComplete : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public CountyCRUDComplete(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Município")]
        [Trait("CRUD", "CountyEntity")]
        public async Task ShouldCRUDCounty()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _repository = new CountyImplementation(context);
                CountyEntity _entity = new CountyEntity
                {
                    Name = Address.City(),
                    CodeIBGE = RandomNumber.Next(1000000, 9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _registerCreated = await _repository.InsertAsync(_entity);
                Assert.NotNull(_registerCreated);
                Assert.Equal(_entity.Name, _registerCreated.Name);
                Assert.Equal(_entity.CodeIBGE, _registerCreated.CodeIBGE);
                Assert.Equal(_entity.UFId, _registerCreated.UFId);
                Assert.False(_entity.Id == Guid.Empty);

                _entity.Name = Address.City();
                _entity.Id = _registerCreated.Id;

                var _registerUpdated = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_registerUpdated);
                Assert.Equal(_entity.Name, _registerUpdated.Name);
                Assert.Equal(_entity.CodeIBGE, _registerUpdated.CodeIBGE);
                Assert.Equal(_entity.UFId, _registerUpdated.UFId);
                Assert.True(_registerCreated.Id == _entity.Id);

                var _existRegister = await _repository.ExistAsync(_registerUpdated.Id);
                Assert.True(_existRegister);

                var _registerSelected = await _repository.SelectAsync(_registerUpdated.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.Name, _registerSelected.Name);
                Assert.Equal(_registerUpdated.CodeIBGE, _registerSelected.CodeIBGE);
                Assert.Equal(_registerUpdated.UFId, _registerSelected.UFId);
                Assert.Null(_registerSelected.UF);

                _registerSelected = await _repository.GetCompleteByIBGE(_registerUpdated.CodeIBGE);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.Name, _registerSelected.Name);
                Assert.Equal(_registerUpdated.CodeIBGE, _registerSelected.CodeIBGE);
                Assert.Equal(_registerUpdated.UFId, _registerSelected.UFId);
                Assert.NotNull(_registerSelected.UF);

                _registerSelected = await _repository.GetCompleteById(_registerUpdated.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.Name, _registerSelected.Name);
                Assert.Equal(_registerUpdated.CodeIBGE, _registerSelected.CodeIBGE);
                Assert.Equal(_registerUpdated.UFId, _registerSelected.UFId);
                Assert.NotNull(_registerSelected.UF);

                var _registersAll = await _repository.SelectAsync();
                Assert.NotNull(_registersAll);
                Assert.True(_registersAll.Count() > 0);

                var _removed = await _repository.DeleteAsync(_registerSelected.Id);
                Assert.True(_removed);

                _registersAll = await _repository.SelectAsync();
                Assert.NotNull(_registersAll);
                Assert.True(_registersAll.Count() == 0);
            }
        }
    }
}
