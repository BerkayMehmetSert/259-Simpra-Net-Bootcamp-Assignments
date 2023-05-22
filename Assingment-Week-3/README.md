[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/gaQlcHTs)
# aw3-template 

simapi projesindeki Category ve Product modelleri 1-M relation olacak sekilde yeniden modelleyiniz.
Iki model icin iligli controllerlari yeniden duzenleyiniz. 
Iki modeli iceren bir migration dosyasi hazirlayip ekleyiniz. 
odev icersinde sadece 2 modeli gonderiniz. 

---

## Product API

Product API, ürünlerin ve ürünlere ait kategorilerin yönetimi için CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren bir Web API uygulamasıdır.

### Proje Yapısı

Proje aşağıdaki bileşenlere ayrılmıştır:

- **API**: Web API katmanı, HTTP isteklerini karşılar ve yanıtlar.
    - **Controllers**: API isteklerini karşılayan controller sınıflarını içeren klasördür.

- **Application**: Uygulama katmanı, API ile UI/CLI arasındaki iletişimi sağlar ve iş mantığını yönetir.
    - **Contracts**: Uygulama içindeki farklı bileşenler arasında veri akışını sağlamak için kullanılan sınıf ve arayüzleri (interface) içerir. 
      - **Mapper**: AutoMapper konfigürasyonlarını içeren klasördür.
      - **Messages**: İşlem sonucu mesajlarını içeren klasördür.
      - **Repositories**: Repository arayüzlerini içeren klasördür.
      - **Requests**: İstek modellerini içeren klasördür.
      - **Responses**: Yanıt modellerini içeren klasördür.
      - **Services**: İş arayüzlerini içeren klasördür.
      - **Validators**: Fluent Validation doğrulama kurallarını içeren klasördür.
    - **Services**: Uygulama katmanında kullanılan iş sınıflarını içeren klasördür.
    - **ApplicationExtensions**: Uygulama katmanına ait olan yapılandırma uzantılarını içeren sınıftır.

- **Domain**: Domain katmanı, iş mantığı modellerini ve kurallarını içerir.
    - **Common**: Ortak iş mantığı modellerini içeren klasördür.
    - **Entities**: Varlık (entity) sınıflarını içeren klasördür.

- **Infrastructure**: Altyapı katmanı, hata yönetimi için gerekli olan yapıları içerir.
    - **Exceptions**: Hata sınıflarını içeren klasördür.
  
- **Persistence** : Persistence katmanı, veritabanı işlemlerini gerçekleştirir.
    - **Context**: Veritabanı bağlantı noktasını içeren klasördür.
    - **EntityConfiguration**: Varlık yapılandırma sınıflarını içeren klasördür.
    - **Migrations**: Veritabanı migrasyonlarını içeren klasördür.
    - **Repositories**: Repository sınıflarını içeren klasördür.
    - **PersistenceExtensions**: Persistence katmanına ait olan yapılandırma uzantılarını içeren sınıftır.

### Kurulum

1. Projeyi klonlayın:
```shell
git clone https://github.com/BerkayMehmetSert/259-Simpra-Net-Bootcamp-Assignments.git
```

2. Proje klasörüne gidin:
```shell
cd Assingment-Week-3
cd Net.Assignment.Week3
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

**Category**

- **GET /api/category**: Tüm kategori kayıtlarını listeler.
- **GET /api/category/{id}**: Belirtilen ID'ye sahip kategori kaydını alır.
- **GET /api/category/name/{name}**: Belirtilen isime sahip kategori kaydını alır.
- **POST /api/category**: Yeni kategori kaydı oluşturur.
- **PUT /api/category/{id}**: Belirtilen ID'ye sahip kategori kaydını günceller.
- **DELETE /api/category/{id}**: Belirtilen ID'ye sahip kategori kaydını siler.

**Product**

- **GET /api/product**: Tüm ürün kayıtlarını listeler.
- **GET /api/product/{id}**: Belirtilen ID'ye sahip ürün kaydını alır.
- **GET /api/product/name/{name}**: Belirtilen isime sahip ürün kaydını alır.
- **POST /api/product**: Yeni ürün kaydı oluşturur.
- **PUT /api/product/{id}**: Belirtilen ID'ye sahip ürün kaydını günceller.
- **PUT /api/product/{id}/category/{categoryId}**: Belirtilen ID'ye sahip ürün kaydının kategorisini günceller.
- **DELETE /api/product/{id}**: Belirtilen ID'ye sahip ürün kaydını siler.

### Veri Modelleri

#### CreateCategoryRequest

Yeni kategori kaydı oluşturmak için kullanılan istek modeli.

```json
{
  "Name": "Category 1",
  "Order": 1
}
```

#### UpdateCategoryRequest

Kategori kaydını güncellemek için kullanılan istek modeli.

```json
{
  "Name": "Category 1",
  "Order": 1
}
```

#### CategoryResponse

Kategori kaydını almak için kullanılan yanıt modeli.

```json
{
  "Id": 1,
  "Name": "Category 1",
  "Order": 1,
  "Products": [
    {
      "Id": 1,
      "CategoryId": 1,
      "Name": "Product 1",
      "Url": "/Product",
      "Tag": "#Product"
    }
  ]
}
```

#### CreateProductRequest

Yeni ürün kaydı oluşturmak için kullanılan istek modeli.

```json
{
  "CategoryId": 1,
  "Name": "Product 1",
  "Url": "/Product",
  "Tag": "#Product"
}
```

#### UpdateProductRequest

Ürün kaydını güncellemek için kullanılan istek modeli.

```json
{
  "Name": "Product 1",
  "Url": "/Product",
  "Tag": "#Product"
}
```

#### ProductResponse

Ürün kaydını almak için kullanılan yanıt modeli.

```json
{
  "Id": 1,
  "CategoryId": 1,
  "Name": "Product 1",
  "Url": "/Product",
  "Tag": "#Product"
}
```