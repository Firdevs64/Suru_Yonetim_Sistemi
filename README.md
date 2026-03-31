# 🐄 Sürü Yönetim Sistemi (Herd Management System)

Bu proje, büyükbaş hayvanların (inek, düve vb.) takibini yapmak, sağlık durumlarını izlemek, olayları yönetmek ve hatırlatmalar oluşturmak amacıyla geliştirilmiş bir **Sürü Yönetim Sistemi**dir.

Proje kapsamında hem **veritabanı tasarımı**, hem **backend API geliştirme**, hem de **AI destekli analiz** altyapısı oluşturulmuştur.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- Swagger (API test ve dokümantasyon)
- RESTful API mimarisi

---

## 🗄️ Veritabanı Yapısı

Projede aşağıdaki temel tablolar oluşturulmuştur:

- `Animals` → Hayvan bilgileri
- `Events` → Hayvanlara ait olaylar (tohumlama, aşı vb.)
- `EventTypes` → Olay türleri
- `Reminders` → Hatırlatmalar
- `Notifications` → Bildirimler
- `Users` → Kullanıcılar
- `AIAnalysisLogs` → AI analiz kayıtları
- `AIChatHistory` → AI sohbet geçmişi

Ayrıca performans ve analiz için aşağıdaki **View’ler** oluşturulmuştur:

- `vw_AnimalSummary`
- `vw_ReminderSummary`
- `vw_EventHistory`
- `vw_AI_AnimalInsights`

---

## ⚙️ Backend (API)

Proje kapsamında ASP.NET Core Web API geliştirilmiştir.

### 🔹 Animals API
- Tüm hayvanları listeleme
- ID ile hayvan getirme
- Hayvan ekleme / güncelleme / silme
- Arama (search)

### 🔹 Events API
- Hayvana ait olayları listeleme

### 🔹 Reminders API
- Tüm hatırlatmalar
- Aktif hatırlatmalar

### 🔹 Dashboard API
- Toplam hayvan sayısı
- Gebe / boş / sağlıklı / sağmal sayıları

### 🔹 Notifications API
- Okundu / okunmadı yönetimi

---

## 🤖 AI Özellikleri

Projede temel seviyede bir **AI analiz sistemi** geliştirilmiştir.
Tüm AI işlemleri veritabanına kaydedilmektedir.
