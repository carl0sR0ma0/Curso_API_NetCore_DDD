namespace Domain.Models
{
    public class ZipCodeModel : BaseModel
    {
		private string? _zipCode;

		public string? ZipCode
		{
			get { return _zipCode; }
			set { _zipCode = value; }
		}

		private string? _publicPlace;

		public string? PublicPlace
		{
			get { return _publicPlace; }
			set { _publicPlace = value; }
		}

		private string? _number;

		public string? Number
		{
			get { return _number; }
			set { _number = string.IsNullOrEmpty(value) ? "S/N" : value; }
		}

		private Guid _countyId;

		public Guid CountyId
		{
			get { return _countyId; }
			set { _countyId = value; }
		}
	}
}
