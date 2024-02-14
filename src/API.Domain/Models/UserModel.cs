namespace Domain.Models
{
    public class UserModel : BaseModel
    {
		private string _name = string.Empty;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _email = string.Empty;
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
	}
}
