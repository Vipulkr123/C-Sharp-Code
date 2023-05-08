
namespace Practical_3
{
    internal class Sponsor
    {
        protected string Owner = "Rakuteen";
    }
    internal class Team : Sponsor
    {
        private readonly string _teamName;
        public Team(string teamName)
        {
            this._teamName = teamName;
        }
        public string PrintInfo()
        {
           return Owner + " " + _teamName;
        }
    }
}
