# IO.Swagger.Api.WebinApi

All URIs are relative to *http://petstore.swagger.io/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetDayWebinars**](WebinApi.md#getdaywebinars) | **GET** /webin/day | Получение перечня вебинаров на день пользователем.
[**GetWebinarConnection**](WebinApi.md#getwebinarconnection) | **GET** /webin/{webinar_id}/connect | Получение ссылки на подключения к вебинару.
[**GetWebinarFileToDownload**](WebinApi.md#getwebinarfiletodownload) | **GET** /webin/{webinar_id}/files/{file_id} | Получение файла вебинара пользователем.
[**GetWebinarFiles**](WebinApi.md#getwebinarfiles) | **GET** /webin/{webinar_id}/files | Получение перечня файлов вебинара пользователем.
[**GetWebinarStatic**](WebinApi.md#getwebinarstatic) | **GET** /webin/{webinar_id}/static | Получение статистики вебинара.
[**GetWeekWebinars**](WebinApi.md#getweekwebinars) | **GET** /webin | Получение перечня вебинаров на неделю пользователем.
[**PostWebinarFiles**](WebinApi.md#postwebinarfiles) | **POST** /webin/{webinar_id}/files | Выгрузка файлов вебинара преподавателем.


<a name="getdaywebinars"></a>
# **GetDayWebinars**
> List<Webinar> GetDayWebinars (string token)

Получение перечня вебинаров на день пользователем.

Полуение пользователем перечня вебинаров на протяжении всего дня по его token-у.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetDayWebinarsExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.

            try
            {
                // Получение перечня вебинаров на день пользователем.
                List&lt;Webinar&gt; result = apiInstance.GetDayWebinars(token);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.GetDayWebinars: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 

### Return type

[**List<Webinar>**](Webinar.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwebinarconnection"></a>
# **GetWebinarConnection**
> InlineResponse2001 GetWebinarConnection (string token, Guid? webinarId)

Получение ссылки на подключения к вебинару.

Выгрузка файлов вебинара преподавателем и администратором по ID вебинара с подверждением авторизации через token.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWebinarConnectionExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.
            var webinarId = new Guid?(); // Guid? | Индетификатор вебинара, по которому желаем выгрузить файл.

            try
            {
                // Получение ссылки на подключения к вебинару.
                InlineResponse2001 result = apiInstance.GetWebinarConnection(token, webinarId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.GetWebinarConnection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 
 **webinarId** | [**Guid?**](Guid?.md)| Индетификатор вебинара, по которому желаем выгрузить файл. | 

### Return type

[**InlineResponse2001**](InlineResponse2001.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwebinarfiletodownload"></a>
# **GetWebinarFileToDownload**
> string GetWebinarFileToDownload (string token, Guid? webinarId, Guid? fileId)

Получение файла вебинара пользователем.

Получение файла пользователем пройденного вебинара по его ID, с подверждением авторизации при помощи token-а и указанием вебинара через его ID.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWebinarFileToDownloadExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.
            var webinarId = new Guid?(); // Guid? | Индетификатор вебинара, по которому желаем получить файл.
            var fileId = new Guid?(); // Guid? | Индетификатор файла, который желаем скачать.

            try
            {
                // Получение файла вебинара пользователем.
                string result = apiInstance.GetWebinarFileToDownload(token, webinarId, fileId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.GetWebinarFileToDownload: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 
 **webinarId** | [**Guid?**](Guid?.md)| Индетификатор вебинара, по которому желаем получить файл. | 
 **fileId** | [**Guid?**](Guid?.md)| Индетификатор файла, который желаем скачать. | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwebinarfiles"></a>
# **GetWebinarFiles**
> List<ModelFile> GetWebinarFiles (string token, Guid? webinarId)

Получение перечня файлов вебинара пользователем.

Получение перечня файлов вебинара пользователями по ID вебинара с подверждением авторизации через token.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWebinarFilesExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.
            var webinarId = new Guid?(); // Guid? | Индетификатор вебинара, по которому желаем получить перечень файлов.

            try
            {
                // Получение перечня файлов вебинара пользователем.
                List&lt;ModelFile&gt; result = apiInstance.GetWebinarFiles(token, webinarId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.GetWebinarFiles: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 
 **webinarId** | [**Guid?**](Guid?.md)| Индетификатор вебинара, по которому желаем получить перечень файлов. | 

### Return type

[**List<ModelFile>**](ModelFile.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getwebinarstatic"></a>
# **GetWebinarStatic**
> Webinar GetWebinarStatic (string token, Guid? webinarId)

Получение статистики вебинара.

Полуение преподавателем и администратором статистики пройденного вебинара по его ID, с подверждением авторизации при помощи token-а.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWebinarStaticExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.
            var webinarId = new Guid?(); // Guid? | Индетификатор вебинара, по которому желаем получить статистику.

            try
            {
                // Получение статистики вебинара.
                Webinar result = apiInstance.GetWebinarStatic(token, webinarId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.GetWebinarStatic: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 
 **webinarId** | [**Guid?**](Guid?.md)| Индетификатор вебинара, по которому желаем получить статистику. | 

### Return type

[**Webinar**](Webinar.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getweekwebinars"></a>
# **GetWeekWebinars**
> List<Webinar> GetWeekWebinars (string token)

Получение перечня вебинаров на неделю пользователем.

Полуение пользователем перечня вебинаров на протяжении всей недели по его token-у.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetWeekWebinarsExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.

            try
            {
                // Получение перечня вебинаров на неделю пользователем.
                List&lt;Webinar&gt; result = apiInstance.GetWeekWebinars(token);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.GetWeekWebinars: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 

### Return type

[**List<Webinar>**](Webinar.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postwebinarfiles"></a>
# **PostWebinarFiles**
> string PostWebinarFiles (string token, Guid? webinarId, ModelFile uploadedFile)

Выгрузка файлов вебинара преподавателем.

Выгрузка файлов вебинара преподавателем и администратором по ID вебинара с подверждением авторизации через token.

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostWebinarFilesExample
    {
        public void main()
        {
            var apiInstance = new WebinApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.
            var webinarId = new Guid?(); // Guid? | Индетификатор вебинара, по которому желаем выгрузить файл.
            var uploadedFile = new ModelFile(); // ModelFile | The file to upload.

            try
            {
                // Выгрузка файлов вебинара преподавателем.
                string result = apiInstance.PostWebinarFiles(token, webinarId, uploadedFile);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WebinApi.PostWebinarFiles: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Токен пользователя, выданный при аутентификации. | 
 **webinarId** | [**Guid?**](Guid?.md)| Индетификатор вебинара, по которому желаем выгрузить файл. | 
 **uploadedFile** | **ModelFile**| The file to upload. | 

### Return type

**string**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

