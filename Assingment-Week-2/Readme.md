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
git clone https://github.com/P259-Simpra-NET-Bootcamp/aw2-BerkayMehmetSert.git
```

2. Proje klasörüne gidin:
```shell
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
