using Intro_Web_ASP.Controllers;

namespace Intro_Web_ASP.Services
{
    public class PeopleService:IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) || people.Name.Length > 100)
            {
                return false;
            }
            return true;
        }
    }
}
