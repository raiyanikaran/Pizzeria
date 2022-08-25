using pizzeria.interfaces.Common;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.interfaces.Items
{
    public interface ICrustSauceRepository : IBaseRepository<CrustSauce>
    {
        List<CrustSauce> GetAllCrustSauce();
    }
}
