using Data.Context;
using Data.Implementations;
using Domain.Entities;
using Faker;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Test
{
    public class ZipCodeCRUDComplete : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public ZipCodeCRUDComplete(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de CEPs")]
        [Trait("CRUD", "ZipCodeEntity")]
        public async Task ShouldCRUDZipCode()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                CountyImplementation _countyRepository = new CountyImplementation(context);
                CountyEntity _countyEntity = new CountyEntity
                {
                    Name = Address.City(),
                    CodeIBGE = RandomNumber.Next(1000000, 9999999),
                    UFId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
                };

                var _countyRegisterCreated = await _countyRepository.InsertAsync(_countyEntity);
                Assert.NotNull(_countyRegisterCreated);
                Assert.Equal(_countyEntity.Name, _countyRegisterCreated.Name);
                Assert.Equal(_countyEntity.CodeIBGE, _countyRegisterCreated.CodeIBGE);
                Assert.Equal(_countyEntity.UFId, _countyRegisterCreated.UFId);
                Assert.False(_countyEntity.Id == Guid.Empty);

                ZipCodeImplementation _zipCodeRepository = new ZipCodeImplementation(context);
                ZipCodeEntity _entity = new ZipCodeEntity
                {
                    ZipCode = Address.ZipCode(),
                    PublicPlace = Address.StreetName(),
                    Number = "0 até 2000",
                    CountyId = _countyEntity.Id
                };

                var _registerCreated = await _zipCodeRepository.InsertAsync(_entity);
                Assert.NotNull(_registerCreated);
                Assert.Equal(_entity.ZipCode, _registerCreated.ZipCode);
                Assert.Equal(_entity.PublicPlace, _registerCreated.PublicPlace);
                Assert.Equal(_entity.Number, _registerCreated.Number);
                Assert.Equal(_entity.CountyId, _registerCreated.CountyId);
                Assert.False(_entity.Id == Guid.Empty);

                _entity.PublicPlace = Address.StreetName();
                _entity.Id = _registerCreated.Id;

                var _registerUpdated = await _zipCodeRepository.UpdateAsync(_entity);
                Assert.NotNull(_registerUpdated);
                Assert.Equal(_entity.ZipCode, _registerUpdated.ZipCode);
                Assert.Equal(_entity.PublicPlace, _registerUpdated.PublicPlace);
                Assert.Equal(_entity.Number, _registerUpdated.Number);
                Assert.Equal(_entity.CountyId, _registerUpdated.CountyId);
                Assert.True(_registerCreated.Id == _entity.Id);

                var _existRegister = await _zipCodeRepository.ExistAsync(_registerUpdated.Id);
                Assert.True(_existRegister);

                var _registerSelected = await _zipCodeRepository.SelectAsync(_registerUpdated.Id);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.ZipCode, _registerSelected.ZipCode);
                Assert.Equal(_registerUpdated.PublicPlace, _registerSelected.PublicPlace);
                Assert.Equal(_registerUpdated.Number, _registerSelected.Number);
                Assert.Equal(_registerUpdated.CountyId, _registerSelected.CountyId);

                _registerSelected = await _zipCodeRepository.SelectAsync(_registerUpdated.ZipCode);
                Assert.NotNull(_registerSelected);
                Assert.Equal(_registerUpdated.ZipCode, _registerSelected.ZipCode);
                Assert.Equal(_registerUpdated.PublicPlace, _registerSelected.PublicPlace);
                Assert.Equal(_registerUpdated.Number, _registerSelected.Number);
                Assert.Equal(_registerUpdated.CountyId, _registerSelected.CountyId);
                Assert.NotNull(_registerSelected.County);
                Assert.Equal(_countyEntity.Name, _registerUpdated.County.Name);
                Assert.NotNull(_registerSelected.County.UF);
                Assert.Equal("SP", _registerUpdated.County.UF.Initials);

                var _registersAll = await _zipCodeRepository.SelectAsync();
                Assert.NotNull(_registersAll);
                Assert.True(_registersAll.Count() > 0);

                var _removed = await _zipCodeRepository.DeleteAsync(_registerSelected.Id);
                Assert.True(_removed);

                _registersAll = await _zipCodeRepository.SelectAsync();
                Assert.NotNull(_registersAll);
                Assert.True(_registersAll.Count() == 0);
            }
        }
    }
}
