# WhatsApp Cloud API

La aplicación usa la plantilla aprobada por Meta: los nombres de las plantillas y sus imágenes se leen desde `WhatsAppConfig`. El código no contiene el precio ni los textos comerciales.
El idioma también es configurable mediante `MetaLanguageCode`. Para la plantilla estándar `hello_world`, normalmente se debe usar `en_US`; para tus plantillas propias en español, usar el locale exacto que aparece en Meta Business Manager, por ejemplo `es_AR`.

## Configuración

Ejecutar `script_whatsapp.sql` en la base existente y cargar una única fila en `WhatsAppConfig`. `MetaAccessToken` debe ser un token válido de Meta y no debe subirse al repositorio. Las URLs de imagen deben ser públicas, HTTPS y accesibles por Meta.

Los endpoints de prueba requieren el header `X-WhatsApp-Admin-Key`, cuyo valor se configura como `WhatsApp:AdminKey` (en Azure, Application Setting). Ejemplos:

```http
POST /api/whatsapp/test
X-WhatsApp-Admin-Key: dev-whatsapp-admin-key
Content-Type: application/json

{"telefono":"11 2233-4455"}
```

```http
POST /api/whatsapp/run
X-WhatsApp-Admin-Key: dev-whatsapp-admin-key
```

El proyecto `WhatsAppFunction` contiene el Timer Trigger .NET 8 Isolated. El timer recomendado es `0 0 13 * * *` (13:00 UTC, 10:00 Argentina), configurado mediante `WhatsAppTimerSchedule`. En Azure deben configurarse `ConnectionStrings__Produccion` y `WhatsAppTimerSchedule` como Application Settings.