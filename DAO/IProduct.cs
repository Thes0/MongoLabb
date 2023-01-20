using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MONGOLABB3.DAO
{
    internal interface IProduct
    {
        bool Create(FishingProductModel fiskesaker);

        List<FishingProductModel> ReadAll();

        void Update(FishingProductModel fiskesaker, FishingProductModel updatedproduct);

        void Delete(FishingProductModel product);
        
    }
}
