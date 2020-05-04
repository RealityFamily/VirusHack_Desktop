# IO.Swagger.Api.UserApi

All URIs are relative to *http://petstore.swagger.io/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetUserInfo**](UserApi.md#getuserinfo) | **GET** /user | Получение информации по пользователю
[**LoginUser**](UserApi.md#loginuser) | **POST** /user/login | Аутентификация пользователя
[**LogoutUser**](UserApi.md#logoutuser) | **GET** /user/logout | Выход из системы пользователем.


<a name="getuserinfo"></a>
# **GetUserInfo**
> User GetUserInfo (string token)

Получение информации по пользователю

Получение информации о пользователю по отправленному им token-у

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetUserInfoExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var token = token_example;  // string | Токен пользователя, выданный при аутентификации.

            try
            {
                // Получение информации по пользователю
                User result = apiInstance.GetUserInfo(token);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.GetUserInfo: " + e.Message );
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

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="loginuser"></a>
# **LoginUser**
> InlineResponse200 LoginUser (Login login)

Аутентификация пользователя

Аутентификация пользователя в системе при помощи доменов @edu.mirea.ru или @mirea.ru

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LoginUserExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var login = new Login(); // Login | Email для аутентификации

            try
            {
                // Аутентификация пользователя
                InlineResponse200 result = apiInstance.LoginUser(login);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.LoginUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **login** | [**Login**](Login.md)| Email для аутентификации | 

### Return type

[**InlineResponse200**](InlineResponse200.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="logoutuser"></a>
# **LogoutUser**
> void LogoutUser (string token)

Выход из системы пользователем.

Выход из системы пользователем и удаление token-а из системы

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class LogoutUserExample
    {
        public void main()
        {
            var apiInstance = new UserApi();
            var token = token_example;  // string | Используемый токен пользователем для его удаления

            try
            {
                // Выход из системы пользователем.
                apiInstance.LogoutUser(token);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling UserApi.LogoutUser: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| Используемый токен пользователем для его удаления | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

