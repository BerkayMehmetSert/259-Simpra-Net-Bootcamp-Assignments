[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/EtuTo9DT)
Projede eksik olarak birakilan DapperRepository class in implemantasyonunu tamamlayiniz.
Insert Update Delete GetAll,GetById methodlari ile calisacak halde methodlari implement edininiz.
Category modeli icin dapper servis hazirlayiniz. Bu servis Dynamic Dapper repository ile calisacak halde olmali.
Bu servis icin standart bir controller implement ediniz.  (GetAll,GetById,Insert,Update,Delete)
Projede kullanilan tum DI islemlerini autofac ile olacak sekilde degistiriniz.
TransactionReportController dapper yerine EF ile calisacak sekilde guncelleyiniz.

---

- [x] DapperRepository sınıfı yardımcı `DapperRepositoryHelper` sınıfı ile birlikte tamamlandı.
- [x] Category modeli için `IDapperCategoryService` ve `DapperCategoryService` sınıfları oluşturuldu.
- [x] `IDapperCategoryService` ve `DapperCategoryService` sınıfları için `DapperCategoryController` oluşturuldu.
- [X] `DapperCategoryController` sınıfı için **GetAll**, **GetById**, **Insert**, **Update**, **Delete** metodları eklendi.
- [x] Tüm Dependency Injection işlemleri **Autofac** ile değiştirildi. `AutofacBusinessModule` sınıfı oluşturuldu.
- [x] TransactionReport için `EFTransactionReportService` sınıfı oluşturuldu. `ITransactionReportService` arayüzü implemente edildi.
- [x] `EFTransactionReportService` sınıfı için `EFTransactionReportController` oluşturuldu.