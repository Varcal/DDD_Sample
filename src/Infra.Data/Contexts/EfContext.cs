using System.Data.Entity;

namespace Infra.Data.Contexts
{
    public class EfContext: DbContext
    {
        public EfContext(): base("Name=DefaultConnection")
        {
            
        }
    }
}
