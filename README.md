```bash
 YourProjectName/
├── YourProjectName.Domain/          # Domain katmanı (Entity'ler, Arayüzler, Temel kurallar)
│   ├── Entities/
│   │   └── User.cs                 # User entity
│   │   └── Role.cs                 # Role entity
│   │   └── UserRole.cs             # UserRole entity
│   ├── Interfaces/
│   │   └── IUserRepository.cs      # UserRepository arayüzü
│   └── ...
│
├── YourProjectName.Application/     # Application katmanı (Servisler, CommandHandler'lar, DTO'lar)
│   ├── Services/
│   │   └── IUserService.cs         # UserService arayüzü
│   │   └── UserService.cs          # UserService implementasyonu
│   ├── Commands/
│   │   └── CreateUserCommand.cs    # CreateUserCommand
│   │   └── CreateUserCommandHandler.cs # CommandHandler
│   └── ...
│
├── YourProjectName.Infrastructure/  # Infrastructure katmanı (Repository implementasyonları, DB Context)
│   ├── Persistence/
│   │   ├── Repositories/
│   │   │   └── UserRepository.cs  # UserRepository implementasyonu
│   │   ├── ApplicationDbContext.cs # DbContext
│   └── ...
│
└── YourProjectName.API/             # API katmanı (Controller'lar)
    ├── Controllers/
    │   └── UsersController.cs       # API Controller
    └── ...
```

Proje Yapısı ve Katman Açıklamaları
1. YourProjectName.Domain
Bu katman, Domain (Alan) katmanı olarak bilinir ve iş kurallarınızı ve çekirdek modellerinizi içerir. Domain katmanı, uygulamanızın merkezini oluşturur ve aşağıdaki bileşenleri içerir:

Entities: Uygulamanızın ana iş varlıklarını temsil eder. Bu sınıflar, sistemdeki ana iş birimlerini ve iş kurallarını içerir.

User.cs: Kullanıcı varlığını (entity) tanımlar.
Role.cs: Kullanıcı rolleriyle ilgili verileri içerir.
UserRole.cs: Kullanıcılar ile roller arasındaki ilişkiyi tanımlar (çoktan çoğa ilişki).
Interfaces: Repository ve diğer bileşenler için arayüzler bulunur. Bu arayüzler, veri erişimi işlemlerini tanımlar.

IUserRepository.cs: Kullanıcılar için veri erişim yöntemlerini tanımlayan bir arayüzdür.
Sorumluluklar:

Domain katmanı, uygulamanın temel iş mantığını ve modellerini içerir.
Diğer katmanlardan bağımsızdır ve sadece iş kurallarını içerir.
Bu katmanda herhangi bir veritabanı veya UI mantığı bulunmaz.
2. YourProjectName.Application
Application (Uygulama) katmanı, iş mantığının servislerle uygulandığı ve veri erişimi ile iş kurallarını birbirine bağlayan katmandır. Command-Query Responsibility Segregation (CQRS) modelini uygular.

Services: İş mantığınızı kapsayan servisler yer alır. Servisler, veri işleme ve iş kurallarını yönetmek için Repository'ler ile etkileşir.

IUserService.cs: Kullanıcılarla ilgili iş mantığını tanımlayan servis arayüzü.
UserService.cs: IUserService'i implemente eden ve kullanıcı yönetimi için gerekli iş mantığını içeren sınıf.
Commands: CQRS mimarisiyle komutları (yazma işlemleri) yöneten sınıflar. Bir nesne oluşturma, güncelleme veya silme gibi işlemleri içerir.

CreateUserCommand.cs: Yeni bir kullanıcı oluşturma komutunu tanımlar.
CreateUserCommandHandler.cs: CreateUserCommand'ı işleyerek yeni bir kullanıcı oluşturan handler (işleyici).
Sorumluluklar:

Application katmanı, iş mantığını ve veri erişimi işlemlerini koordine eder.
Bu katmanda servisler aracılığıyla iş mantığı uygulanır ve CQRS kullanarak komutlar işlenir.
Veri erişimi ve iş mantığı birbirinden soyutlanır ve servislerle yönetilir.
3. YourProjectName.Infrastructure
Infrastructure (Altyapı) katmanı, veri erişimi ve diğer altyapı servislerini içerir. Veritabanı işlemleri, dış servislerle entegrasyonlar ve sistem dışı bağımlılıklar bu katmanda yönetilir.

Persistence: Kalıcı veritabanı işlemlerinin yönetildiği katmandır.
Repositories: Veri erişim işlemlerini gerçekleştiren sınıfları içerir.
UserRepository.cs: IUserRepository arayüzünü implemente eden ve kullanıcılar ile ilgili veri işlemlerini gerçekleştiren repository.
ApplicationDbContext.cs: Entity Framework Core ile veri işlemlerini yöneten sınıf. Bu sınıf, veritabanı tablolarını ve ilişkileri tanımlar.
Sorumluluklar:

Infrastructure katmanı, veri erişimi, dosya yönetimi, ağ iletişimi ve diğer altyapı gereksinimlerini yönetir.
Repository sınıfları, veritabanı ile etkileşimi sağlar ve veri manipülasyon işlemlerini gerçekleştirir.
Uygulamanın veritabanı işlemlerini soyutlar ve Application katmanına bu işlemleri sunar.
4. YourProjectName.API
API (Uygulama Programlama Arayüzü) katmanı, uygulamanızın dış dünyaya açılan kapısıdır. Web API'lar veya diğer dış servislerle etkileşim bu katmanda gerçekleşir.

Controllers: API isteklerini yöneten sınıfları içerir. Controller'lar, gelen istekleri alır, gerekli işlemleri başlatır ve sonuçları döner.
UsersController.cs: Kullanıcı yönetimi için API isteklerini alan ve işlemleri başlatan sınıf.
Sorumluluklar:

API katmanı, dış istemcilerden gelen HTTP isteklerini alır ve ilgili işlemleri başlatır.
Controller sınıfları, istekleri Application katmanındaki servislerle işleyerek veri sağlar veya işleme yapar.
Bu katman, uygulamanızın dış dünyaya erişimini sağlar ve dış sistemlerle veri alışverişini yönetir.
Genel Özet
Domain Katmanı: İş kuralları ve veri modelleri içerir. Uygulamanın çekirdeği olup, diğer katmanlardan bağımsızdır.
Application Katmanı: İş mantığı servislerle uygulanır. CQRS modeliyle komutlar ve sorgular bu katmanda işlenir.
Infrastructure Katmanı: Veri erişim katmanıdır. Veritabanı işlemleri, dosya yönetimi ve diğer altyapı gereksinimlerini yönetir.
API Katmanı: Dış dünyadan gelen istekleri karşılar ve veri sağlar. Controller'lar aracılığıyla Application katmanındaki işlemleri başlatır.
