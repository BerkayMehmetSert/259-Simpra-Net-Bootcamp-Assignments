# aw2

Asagida verilen modeli kullanarak GetAll, GetById , Put , Post , Delete methodlarini icen bir controller implement ediniz. 

EF ile generic repository ve UnitOfWork kullanabilirsiniz.

Put  ve Post apilerin de model validation hazirlayiniz.  Fluent validation kullaniniz. 

Extra olarak 2 tane alana gore (Query parameter) filtreleme yapan Filter apisi ekleyiniz (GET) ve WHERE sarti ile database den filtreleme yapiniz. 

Generic Repository uzerinde Where sartini implement ediniz. 

SOLID e uymaya ozen gosteriniz . 

Proje icerisinde sadece odev ile ilgili kisimlara yer veriniz. Kullanilmayan controller ve methodlari gondermeyiniz. Yorum satiri gondermeyininiz.

Model icin initial migration dosyasini ekleyiniz. 

Readme file uzerinde nasil calisacagina dair gerekli aciklamalara yer veriniz. 

Email alanini unique olmalidir. 

```
  public class Staff  
    { 
        public int Id { get; set; } 
        public string CreatedBy { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public string AddressLine1 { get; set; } 
        public string City { get; set; } 
        public string Country { get; set; } 
        public string Province { get; set; } 
        [NotMapped] 
        public string FullName 
        { 
            get { return FirstName + " " + LastName; } 
        } 
    }
```

---
## Staff API

Staff API, personel yönetimi için CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren bir Web API uygulamasıdır.

### Proje Yapısı

Proje aşağıdaki bileşenlere ayrılmıştır:

- **API**: Web API katmanı, HTTP isteklerini karşılar ve yanıtlar.
    - **Controllers**: API isteklerini karşılayan controller sınıflarını içeren klasördür.

- **Application**: Uygulama katmanı, API ile UI/CLI arasındaki iletişimi sağlar ve iş mantığını yönetir.
    - **Constants**: Ortak olarak kullanılan sınıfları içeren klasördür.
    - **FluentValidations**:  Fluent Validation doğrulama kurallarını içeren klasördür.
    - **Mapper**: AutoMapper konfigürasyonlarını içeren klasördür.
    - **Repositories**: Repository arayüzlerini içeren klasördür.
    - **Requests**: İstek modellerini içeren klasördür.
    - **Responses**: Yanıt modellerini içeren klasördür.
    - **Services**: İş sınıfları ve arayüzlerini içeren klasördür.
    - **ApplicationExtensions**: Uygulama katmanına ait olan yapılandırma uzantılarını içeren sınıftır.

- **Domain**: Domain katmanı, iş mantığı modellerini ve kurallarını içerir.
    - **Common**: Ortak iş mantığı modellerini içeren klasördür.
    - **Entities**: Varlık (entity) sınıflarını içeren klasördür.

- **Persistence** : Persistence katmanı, veritabanı işlemlerini gerçekleştirir.
    - **Context**: Veritabanı bağlantı noktasını içeren klasördür.
    - **EntityConfiguration**: Varlık yapılandırma sınıflarını içeren klasördür.
    - **Repositories**: Repository sınıflarını içeren klasördür.
    - **PersistenceExtensions**: Persistence katmanına ait olan yapılandırma uzantılarını içeren sınıftır.

### Kurulum

1. Projeyi klonlayın:
```shell
git clone https://github.com/BerkayMehmetSert/259-Simpra-Net-Bootcamp-Assignments.git
```

2. Proje klasörüne gidin:
```shell
cd Assingment-Week-2
cd Net.Assignment.Week2
```

3. Bağımlılıkları yükleyin:
```shell
dotnet restore
```

4. Veritabanını oluşturun:
```shell
dotnet ef database update
```

5. Uygulamayı başlatın:
```shell
dotnet run
```

### API Endpoint'leri

Aşağıdaki API endpoint'leri mevcuttur:

- **GET /api/staff**: Tüm personel kayıtlarını alır.
- **GET /api/staff/{id}**: Belirtilen ID'ye sahip personel kaydını alır.
- **GET /api/staff/email/{email}**: Belirtilen e-posta adresine sahip personel kaydını alır.
- **GET /api/staff/city/{city}**: Belirtilen şehirdeki personel kayıtlarını alır.
- **POST /api/staff**: Yeni personel kaydı oluşturur.
- **PUT /api/staff/{id}**: Belirtilen ID'ye sahip personel kaydını günceller.
- **DELETE /api/staff/{id}**: Belirtilen ID'ye sahip personel kaydını siler.

### Veri Modelleri

#### CreateStaffRequest

Yeni personel kaydı oluşturmak için kullanılan istek modeli.

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@example.com",
  "phone": "+1 555-555-5555",
  "dateOfBirth": "1990-01-01T00:00:00.000Z",
  "addressLine1": "123 Main St",
  "city": "Anytown",
  "country": "USA",
  "province": "CA"
}
```

#### UpdateStaffRequest

Personel kaydını güncellemek için kullanılan istek modeli.

```json
{
  "firstName": "Jane",
  "lastName": "Smith",
  "email": "janesmith@example.com",
  "phone": "+1 555-123-4567",
  "dateOfBirth": "1985-05-10T00:00:00.000Z",
  "addressLine1": "456 Elm St",
  "city": "Otherville",
  "country": "USA",
  "province": "NY"
}
```

#### StaffResponse

Personel kaydını almak için kullanılan yanıt modeli.

```json
{
  "id": 1,
  "firstName": "John",
  "lastName": "Doe",
  "email": "johndoe@example.com",
  "phone": "+1 555-555-5555",
  "dateOfBirth": "1990-01-01T00:00:00.000Z",
  "addressLine1": "123 Main St",
  "city": "Anytown",
  "country": "USA",
  "province": "CA"
}
```
