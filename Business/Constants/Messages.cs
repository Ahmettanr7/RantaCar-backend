using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };

        public static string CarListed = "Arabalar listelendi";
        public static string DataUpdated = "Veri güncellendi";
        public static string DataDeleted = "Veri silindi";
        public static string DailyPriceInvalid = "Günlük fiyatı geçersiz";
        public static string DataAdded = "Veri eklendi";
        public static string MaintenanceTime = "Sitemiz şuanda bakımdadır 01:00 saati ile işleminizi gerçekleştirebilirsiniz.";


        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandListed = "Marka listelendi";
        public static string brandUpdate = "Marka güncellendi";


        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";


        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";


        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama güncellendi";


        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";


        public static string RentalNotComeBack = "Başka bir araç seçiniz. Bu araç şuan başka müşteride kirada";
        public static string CarIsAtRest = "Bu araç yarın kiralanabilir, şuan bakım ve dinlenmede";
        public static string RentDayCantbePast ="Kiralama işlemi geçmiş tarih olamaz";


        internal static string CarImageListed = "Görseller listelendi";
        internal static string ImageDeleted = "Görsel silindi";
        internal static string ImageAdded = "Görsel eklendi";
        internal static string ImageUpdated = "Görsel güncellendi";
        internal static string CantMoreThanFive = "Araca 5 ten fazla görsel eklenemez";
        internal static string CarHaveNoImage = "Araca ait görsel bulunamadı";
        internal static string InvalidImageExtension = "Geçersiz resim uzantısı";
        internal static string CarImageMustBeExists = "Araba resmi mevcut olmalı";
        
    }
}
