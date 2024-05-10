using BulkyBookWeb.Data;

namespace BulkyBookWeb.Repos
{
    internal class Repo
    {
        internal AppDbContext db;

        internal Repo(AppDbContext db)
        {
            this.db = db;
        }
    }
}
