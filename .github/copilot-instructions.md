# MyMonkeyApp Projesi Talimatları

Bu proje .NET 9 ile yazılmış olup C# 13 kullanmaktadır.

Oluşturulan tüm kodların, ana klasör içerisinde bir alt klasör olarak bulunabilecek olan **MyMonkeyApp** projesi içinde yer aldığından emin olun.

GitHub adresi: https://github.com/aycabas/MonkeyApp

---

## 📌 Proje Hakkında
Bu uygulama, maymun türlerine ait verileri yöneten ve MCP sunucuları aracılığıyla GitHub ile entegre olan bir konsol uygulamasıdır.

---

## 🧑‍💻 C# Kodlama Standartları

- Sınıf, metot ve özellik adlarında **PascalCase** kullanın  
- Yerel değişkenler ve parametrelerde **camelCase** kullanın  
- Amacını açıkça belirten açıklayıcı isimler tercih edin  
- Public sınıflar ve metotlar için **XML dokümantasyon yorumları** ekleyin  
- Tür açıkça belli olduğunda `var` kullanın  
- Okunabilirliği artırmak için gerekirse açık tür belirtin  
- Asenkron işlemlerde `async/await` yapısını kullanın  
- Veri erişimi için **repository (depo) deseni** kullanın  
- Hata yönetimi için `try-catch` blokları kullanın  
- Kaynak yöneten sınıflarda `IDisposable` arayüzünü uygulayın  
- Null referans hatalarını önlemek için nullable referans türlerini kullanın  
- Kodun daha düzenli olması için **file-scoped namespace** kullanın

---

## 🧾 İsimlendirme Kuralları

- **Sınıflar:** `MonkeyHelper`, `Monkey`, `Program`  
- **Metotlar:** `GetMonkeys()`, `GetRandomMonkey()`, `GetMonkeyByName()`  
- **Özellikler:** `Name`, `Location`, `Population`  
- **Değişkenler:** `selectedMonkey`, `monkeyCount`, `userInput`  
- **Sabitler:** `MAX_MONKEYS`, `DEFAULT_POPULATION`

---

## 🧱 Mimari Yapı

- Etkileşimli menüye sahip bir **konsol uygulaması**  
- Veri yönetimi için **statik yardımcı sınıf (helper)**  
- Veri temsili için **model sınıflar**  
- **Kullanıcı arayüzü (UI)** ile **iş mantığı (business logic)** birbirinden ayrılmıştır

