using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Constants
{
    public static class Messages
    {
        public static readonly string ProductAdded = "Ürün eklendi";
        public static readonly string ProductNameLengthInvalid = "Ürün ismi en az 2 karakterden oluşmalıdır";
        public static readonly string MaintenanceTime = "Sistem bakımda";
        public static readonly string ProductsListed = "Ürünler listelendi";
        public static readonly string ProductListed = "Ürün listelendi";
        public static readonly string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün bulunabilir";
        public static readonly string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün bulunmaktadır";
        public static readonly string ProductUpdated = "Ürün güncellendi";

        public static readonly string CategoryLimitExceded = "Kategori limiti aşıldı";
        public static readonly string AuthorizationDenied = "Yetkisiz giriş";
    }
}
