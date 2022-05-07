# Amaç
Deeplink'ten Web Url ve Web Url'den de deeplink çeviren servistir.

# Gereksinimler
 - .Net 3.1 SDK (https://dotnet.microsoft.com/download/dotnet-core/3.1)
 - Redis sunucu adresi. (Docker destop ile https://hub.docker.com/_/redis adresinden pull yapılabilir.)

# Genel Bilgiler
- Swagger Adresi bilgisi ==> [adres]:[port]/swagger/index.html
- Api projesinde Docker dosyası bulunmaktadır. Bu dosya ile Bu projenin image oluşturulabilir.

# Proje Yapısı
- ## Api
    Deeplink ve weburl dönüşümlerinin konfigürasyonları içeren ve bu konfigürasyonlara ile core projesindeki kullanarak bunları bir endpoint haline getiren client projesidir.
- ## Core
    Deeplink ve web url dönüşümlerini yapan temel sınıfları içeren projedir.
- ## Test
    Api ve core projelerinin Testlerinin yazıldığı projedir.
   
