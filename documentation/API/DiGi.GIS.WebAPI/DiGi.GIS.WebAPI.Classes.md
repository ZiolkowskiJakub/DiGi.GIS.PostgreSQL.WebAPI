#### [DiGi\.GIS\.WebAPI](DiGi.GIS.WebAPI.Overview.md 'DiGi\.GIS\.WebAPI\.Overview')

## DiGi\.GIS\.WebAPI\.Classes Namespace
### Classes

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController'></a>

## AdministrativeAreal2DController Class

Web API controller for administrative area 2D operations, providing endpoints to retrieve, filter, and update administrative area data\.

```csharp
public class AdministrativeAreal2DController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → AdministrativeAreal2DController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.AdministrativeAreal2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter)'></a>

## AdministrativeAreal2DController\(GISWebAPIConfigurationFileWatcher, AdministrativeAreal2DPostgreSQLConverter\) Constructor

```csharp
public AdministrativeAreal2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.AdministrativeAreal2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher for the GIS PostgreSQL Web API\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.AdministrativeAreal2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).administrativeAreal2DPostgreSQLConverter'></a>

`administrativeAreal2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter')

The converter used for administrative area 2D PostgreSQL operations\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferenceByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferenceByCodeAsync\(string, Nullable\<AdministrativeArealType\>\) Method

Gets an administrative area reference by its code and type\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferenceByCodeAsync(string? code, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferenceByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique code of the administrative area\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferenceByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The type of the administrative area\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferenceByIdAsync(int)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferenceByIdAsync\(int\) Method

Retrieves an administrative area reference by its identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferenceByIdAsync(int id);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferenceByIdAsync(int).id'></a>

`id` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the administrative area reference to retrieve\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathByIdAsync(int)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferencePathByIdAsync\(int\) Method

Retrieves the administrative area reference path by its identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferencePathByIdAsync(int id);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathByIdAsync(int).id'></a>

`id` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the administrative area reference path to retrieve\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathsByNameAsync(string,System.Threading.CancellationToken)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferencePathsByNameAsync\(string, CancellationToken\) Method

Retrieves administrative area reference paths by name\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferencePathsByNameAsync(string text, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathsByNameAsync(string,System.Threading.CancellationToken).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The search text used to find matching administrative area reference paths\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathsByNameAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used by the called method to indicate that the operation should be canceled\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathsByNameParameterAsync(DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter,System.Threading.CancellationToken)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferencePathsByNameParameterAsync\(AdministrativeAreal2DReferencePathsByNameParameter, CancellationToken\) Method

Retrieves administrative area reference paths by name parameter \(where Text is the search term\)\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferencePathsByNameParameterAsync(DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter administrativeAreal2DReferencePathsByNameParameter, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathsByNameParameterAsync(DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter,System.Threading.CancellationToken).administrativeAreal2DReferencePathsByNameParameter'></a>

`administrativeAreal2DReferencePathsByNameParameter` [AdministrativeAreal2DReferencePathsByNameParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter 'DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DReferencePathsByNameParameter')

The parameter containing the search term for querying administrative areas by name\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencePathsByNameParameterAsync(DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\. List of AdministrativeAreal2DReferencePaths [DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReferencePath](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dreferencepath 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DReferencePath') if valid administrative area references are found\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType,System.Nullable_int_,System.Nullable_bool_)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync\(AdministrativeArealType, Nullable\<int\>, Nullable\<bool\>\) Method

Retrieves all administrative area references filtered by administrative area type\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType administrativeArealType, System.Nullable<int> parentId, System.Nullable<bool> uniqueCode);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType,System.Nullable_int_,System.Nullable_bool_).administrativeArealType'></a>

`administrativeArealType` [DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')

The administrative area type used to filter the references\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType,System.Nullable_int_,System.Nullable_bool_).parentId'></a>

`parentId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional parent identifier used for filtering\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType,System.Nullable_int_,System.Nullable_bool_).uniqueCode'></a>

`uniqueCode` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional flag indicating whether to filter by unique code\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetAdministrativeAreal2DReferencesByCodeAsync\(string, Nullable\<AdministrativeArealType\>\) Method

Retrieves administrative area references by their code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DReferencesByCodeAsync(string code, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier or code used to retrieve the administrative area references\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetAdministrativeAreal2DReferencesByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional filter specifying the type of administrative area\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetCodesAsync()'></a>

## AdministrativeAreal2DController\.GetCodesAsync\(\) Method

Retrieves all available administrative area codes\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetCodesAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetIdByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetIdByCodeAsync\(string, Nullable\<AdministrativeArealType\>\) Method

Retrieves the identifier for a given code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetIdByCodeAsync(string code, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetIdByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique code of the administrative area\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetIdByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional type of the administrative area to filter the search\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemByCodeAsync(string)'></a>

## AdministrativeAreal2DController\.GetItemByCodeAsync\(string\) Method

Retrieves an administrative area item by its code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemByCodeAsync(string code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemByCodeAsync(string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique code of the administrative area to retrieve\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemByIdAsync(int)'></a>

## AdministrativeAreal2DController\.GetItemByIdAsync\(int\) Method

Asynchronously retrieves an administrative area item by its unique identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemByIdAsync(int id);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemByIdAsync(int).id'></a>

`id` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The integer identifier of the administrative area item to retrieve\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType)'></a>

## AdministrativeAreal2DController\.GetItemsByAdministrativeArealTypeAsync\(AdministrativeArealType\) Method

Retrieves all administrative area items filtered by administrative area type\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByAdministrativeArealTypeAsync(DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType).administrativeArealType'></a>

`administrativeArealType` [DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')

The administrative area type used to filter the results\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetItemsByBoundingBoxAsync\(double, double, double, double, Nullable\<double\>, Nullable\<AdministrativeArealType\>\) Method

Retrieves administrative area items within a specified bounding box\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByBoundingBoxAsync(double x_1, double y_1, double x_2, double y_2, System.Nullable<double> tolerance, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).x_1'></a>

`x_1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the first corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).y_1'></a>

`y_1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the first corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).x_2'></a>

`x_2` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the second corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).y_2'></a>

`y_2` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the second corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional tolerance value for the spatial query\. If not provided, a default macro distance is used\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional filter to restrict results to a specific type of administrative area\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetItemsByCircleAsync\(double, double, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, Nullable\<AdministrativeArealType\>\) Method

Retrieves administrative area items within a specified circle\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByCircleAsync(double x, double y, System.Nullable<double> radius, System.Nullable<double> diameter, System.Nullable<double> tolerance, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the center point of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the center point of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).radius'></a>

`radius` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The radius of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).diameter'></a>

`diameter` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The diameter of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The tolerance value for the spatial query\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The type of administrative area to retrieve\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') containing a list of administrative area items if found, or an error response\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetItemsByCodeAsync\(string, Nullable\<AdministrativeArealType\>\) Method

Retrieves administrative area items filtered by code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByCodeAsync(string code, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The code used to filter the administrative area items\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCodeAsync(string,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional type of administrative area to filter by\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') containing a list of matching administrative area items, or an error response if the code is invalid or no items are found\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCodesAsync(System.Collections.Generic.List_string_)'></a>

## AdministrativeAreal2DController\.GetItemsByCodesAsync\(List\<string\>\) Method

Retrieves administrative area items filtered by multiple codes\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByCodesAsync(System.Collections.Generic.List<string> codes);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByCodesAsync(System.Collections.Generic.List_string_).codes'></a>

`codes` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

The list of codes used to filter the administrative area items\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByPointAsync(double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_)'></a>

## AdministrativeAreal2DController\.GetItemsByPointAsync\(double, double, Nullable\<double\>, Nullable\<AdministrativeArealType\>\) Method

Retrieves administrative area items at or near a specified point\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByPointAsync(double x, double y, System.Nullable<double> tolerance, System.Nullable<DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType> administrativeArealType);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByPointAsync(double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the search point\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByPointAsync(double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the search point\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByPointAsync(double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional tolerance distance to use when searching for items near the specified point\. If null, a default macro distance is used\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetItemsByPointAsync(double,double,System.Nullable_double_,System.Nullable_DiGi.GIS.PostgreSQL.Enums.AdministrativeArealType_).administrativeArealType'></a>

`administrativeArealType` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.enums.administrativearealtype 'DiGi\.GIS\.PostgreSQL\.Enums\.AdministrativeArealType')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional type filter for the administrative area items to be retrieved\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetSubCodesAsync(string)'></a>

## AdministrativeAreal2DController\.GetSubCodesAsync\(string\) Method

Retrieves subcodes for a given code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetSubCodesAsync(string code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.GetSubCodesAsync(string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The administrative area code used to retrieve the associated subcodes\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.UpdateItemAsync(System.Text.Json.Nodes.JsonObject)'></a>

## AdministrativeAreal2DController\.UpdateItemAsync\(JsonObject\) Method

Updates a single administrative area item\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemAsync(System.Text.Json.Nodes.JsonObject? jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.UpdateItemAsync(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to update the administrative area item\. This value can be null\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray)'></a>

## AdministrativeAreal2DController\.UpdateItemsAsync\(JsonArray\) Method

Updates multiple administrative area items\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemsAsync(System.Text.Json.Nodes.JsonArray? jsonArray);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the administrative area items to be updated\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter'></a>

## AdministrativeAreal2DReferencePathsByNameParameter Class

Represents a parameter containing text for querying administrative area reference paths\.

```csharp
public class AdministrativeAreal2DReferencePathsByNameParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → AdministrativeAreal2DReferencePathsByNameParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter.AdministrativeAreal2DReferencePathsByNameParameter()'></a>

## AdministrativeAreal2DReferencePathsByNameParameter\(\) Constructor

Initializes a new instance of the [AdministrativeAreal2DReferencePathsByNameParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter 'DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DReferencePathsByNameParameter') class\.

```csharp
public AdministrativeAreal2DReferencePathsByNameParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter.AdministrativeAreal2DReferencePathsByNameParameter(string)'></a>

## AdministrativeAreal2DReferencePathsByNameParameter\(string\) Constructor

Initializes a new instance of the [AdministrativeAreal2DReferencePathsByNameParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter 'DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DReferencePathsByNameParameter') class with the specified text \(search phrase\)\.

```csharp
public AdministrativeAreal2DReferencePathsByNameParameter(string text);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter.AdministrativeAreal2DReferencePathsByNameParameter(string).text'></a>

`text` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The text to search for\.

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter.AdministrativeAreal2DReferencePathsByNameParameter(System.Text.Json.Nodes.JsonObject)'></a>

## AdministrativeAreal2DReferencePathsByNameParameter\(JsonObject\) Constructor

Initializes a new instance of the [AdministrativeAreal2DReferencePathsByNameParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter 'DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DReferencePathsByNameParameter') class using an [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public AdministrativeAreal2DReferencePathsByNameParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter.AdministrativeAreal2DReferencePathsByNameParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing the parameter values\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DReferencePathsByNameParameter.Text'></a>

## AdministrativeAreal2DReferencePathsByNameParameter\.Text Property

Text to search for in the names of the administrative areal 2D reference paths\. The search is case\-insensitive and matches any path whose name contains the specified text\.

```csharp
public string? Text { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DsPostTask'></a>

## AdministrativeAreal2DsPostTask Class

Provides functionality to asynchronously post a collection of [DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D') objects to the PostgreSQL database\.

```csharp
public class AdministrativeAreal2DsPostTask : DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask<DiGi.GIS.Classes.AdministrativeAreal2D>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.GIS\.Classes\.AdministrativeAreal2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.administrativeareal2d 'DiGi\.GIS\.Classes\.AdministrativeAreal2D')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → AdministrativeAreal2DsPostTask
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DsPostTask.AdministrativeAreal2DsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## AdministrativeAreal2DsPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the AdministrativeAreal2DsPostTask class\.

```csharp
public AdministrativeAreal2DsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DsPostTask.AdministrativeAreal2DsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The GIS PostgreSQL Web API manager used to handle database operations\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController'></a>

## Building2DController Class

Web API controller for building 2D operations, providing endpoints to retrieve, filter, and update building 2D data\.

```csharp
public class Building2DController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → Building2DController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.Building2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter)'></a>

## Building2DController\(GISWebAPIConfigurationFileWatcher, Building2DPostgreSQLConverter\) Constructor

```csharp
public Building2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.Building2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher for the GIS PostgreSQL Web API\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.Building2DController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter).building2DPostgreSQLConverter'></a>

`building2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter')

The converter used for Building 2D data operations in PostgreSQL\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.CountAsync(DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter)'></a>

## Building2DController\.CountAsync\(CountByAdministrativeAreal2DIdsParameter\) Method

Asynchronously counts the number of buildings based on the administrative areal 2D identifiers\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> CountAsync(DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter countByAdministrativeAreal2DIdsParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.CountAsync(DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter).countByAdministrativeAreal2DIdsParameter'></a>

`countByAdministrativeAreal2DIdsParameter` [CountByAdministrativeAreal2DIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.CountByAdministrativeAreal2DIdsParameter')

The parameter object containing the collection of administrative areal 2D identifiers\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferenceByIdAsync(long,System.Nullable_int_)'></a>

## Building2DController\.GetBuilding2DReferenceByIdAsync\(long, Nullable\<int\>\) Method

Asynchronously retrieves a building 2D reference by its unique identifier and an optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetBuilding2DReferenceByIdAsync(long id, System.Nullable<int> countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferenceByIdAsync(long,System.Nullable_int_).id'></a>

`id` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The unique identifier of the building\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferenceByIdAsync(long,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional integer representing the county identifier used to filter the search\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferenceByReferenceAsync(string,System.Nullable_int_)'></a>

## Building2DController\.GetBuilding2DReferenceByReferenceAsync\(string, Nullable\<int\>\) Method

Retrieves a building 2D reference by its unique reference code and an optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetBuilding2DReferenceByReferenceAsync(string reference, System.Nullable<int> countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferenceByReferenceAsync(string,System.Nullable_int_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string of the building to retrieve\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferenceByReferenceAsync(string,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional integer identifier of the county used to filter the search\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferencesByAdministrativeAreal2DIdAsync(int)'></a>

## Building2DController\.GetBuilding2DReferencesByAdministrativeAreal2DIdAsync\(int\) Method

Retrieves building 2D references filtered by administrative area 2D identifier\. Can be used for relatively small number of buildings

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetBuilding2DReferencesByAdministrativeAreal2DIdAsync(int administrativeAreal2DId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferencesByAdministrativeAreal2DIdAsync(int).administrativeAreal2DId'></a>

`administrativeAreal2DId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the administrative area 2D used to filter the building references\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferencesByPagingParameterAsync(DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter)'></a>

## Building2DController\.GetBuilding2DReferencesByPagingParameterAsync\(Building2DReferencesByPagingParameter\) Method

Retrieves a paginated list of building 2D references\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetBuilding2DReferencesByPagingParameterAsync(DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter building2DReferencesByPagingParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetBuilding2DReferencesByPagingParameterAsync(DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter).building2DReferencesByPagingParameter'></a>

`building2DReferencesByPagingParameter` [Building2DReferencesByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.Building2DReferencesByPagingParameter')

The parameter containing paging options, including county identifier, cursor, and page size\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning a list of building 2D references\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByIdAsync(long,System.Nullable_int_)'></a>

## Building2DController\.GetItemByIdAsync\(long, Nullable\<int\>\) Method

Retrieves a building 2D item by its identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemByIdAsync(long id, System.Nullable<int> countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByIdAsync(long,System.Nullable_int_).id'></a>

`id` [System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')

The unique identifier of the building 2D item to retrieve\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByIdAsync(long,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional county identifier associated with the building\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByPointAsync(double,double,System.Nullable_double_)'></a>

## Building2DController\.GetItemByPointAsync\(double, double, Nullable\<double\>\) Method

Retrieves a building 2D item at or near a specified point\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemByPointAsync(double x, double y, System.Nullable<double> tolerance);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByPointAsync(double,double,System.Nullable_double_).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X coordinate of the search point\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByPointAsync(double,double,System.Nullable_double_).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y coordinate of the search point\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByPointAsync(double,double,System.Nullable_double_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional tolerance distance to use when searching for the item near the specified point\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') containing the building 2D item if found, or an error response\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByReferenceAsync(string,System.Nullable_int_)'></a>

## Building2DController\.GetItemByReferenceAsync\(string, Nullable\<int\>\) Method

Asynchronously retrieves a building 2D item by its reference code and an optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemByReferenceAsync(string reference, System.Nullable<int> countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByReferenceAsync(string,System.Nullable_int_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string used to locate the building 2D item\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemByReferenceAsync(string,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional identifier of the county associated with the building\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_)'></a>

## Building2DController\.GetItemsByBoundingBoxAsync\(double, double, double, double, Nullable\<double\>\) Method

Retrieves building 2D items within a specified bounding box\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByBoundingBoxAsync(double x_1, double y_1, double x_2, double y_2, System.Nullable<double> tolerance);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_).x_1'></a>

`x_1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the first corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_).y_1'></a>

`y_1` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the first corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_).x_2'></a>

`x_2` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the second corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_).y_2'></a>

`y_2` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the second corner of the bounding box\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBoundingBoxAsync(double,double,double,double,System.Nullable_double_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional tolerance value for the spatial query\. If not provided or NaN, a default macro distance is used\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBuilding2DReferencesAsync(System.Text.Json.Nodes.JsonArray)'></a>

## Building2DController\.GetItemsByBuilding2DReferencesAsync\(JsonArray\) Method

Retrieves building 2D items by their references\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByBuilding2DReferencesAsync(System.Text.Json.Nodes.JsonArray? jsonArray);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByBuilding2DReferencesAsync(System.Text.Json.Nodes.JsonArray).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the building 2D references to retrieve\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_)'></a>

## Building2DController\.GetItemsByCircleAsync\(double, double, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>\) Method

Retrieves building 2D items within a specified circle\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByCircleAsync(double x, double y, System.Nullable<double> radius, System.Nullable<double> diameter, System.Nullable<double> tolerance);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the center of the circle\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the center of the circle\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).radius'></a>

`radius` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The radius of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).diameter'></a>

`diameter` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The diameter of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The tolerance value to be applied to the search area\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetPoint2DsByReferencesAsync(System.Collections.Generic.IEnumerable_string_,System.Nullable_int_)'></a>

## Building2DController\.GetPoint2DsByReferencesAsync\(IEnumerable\<string\>, Nullable\<int\>\) Method

Retrieves Point2D coordinates by their references\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetPoint2DsByReferencesAsync(System.Collections.Generic.IEnumerable<string> references, System.Nullable<int> countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetPoint2DsByReferencesAsync(System.Collections.Generic.IEnumerable_string_,System.Nullable_int_).references'></a>

`references` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

A collection of reference strings used to identify the Point2D objects\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetPoint2DsByReferencesAsync(System.Collections.Generic.IEnumerable_string_,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional identifier for the county associated with the coordinates\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetReferencesByCountyIdAsync(int,System.Nullable_int_)'></a>

## Building2DController\.GetReferencesByCountyIdAsync\(int, Nullable\<int\>\) Method

Retrieves references of the building2Ds filtered by county Id\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetReferencesByCountyIdAsync(int countyId, System.Nullable<int> subdivisionId=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetReferencesByCountyIdAsync(int,System.Nullable_int_).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county used to filter the building 2D references\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.GetReferencesByCountyIdAsync(int,System.Nullable_int_).subdivisionId'></a>

`subdivisionId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the subdivision used to further filter the building 2D references\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.UpdateItemAsync(System.Text.Json.Nodes.JsonObject,string)'></a>

## Building2DController\.UpdateItemAsync\(JsonObject, string\) Method

Updates a single building 2D item\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemAsync(System.Text.Json.Nodes.JsonObject? jsonObject, string? code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.UpdateItemAsync(System.Text.Json.Nodes.JsonObject,string).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data to update the building 2D item\. This value can be null\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.UpdateItemAsync(System.Text.Json.Nodes.JsonObject,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The code identifying the specific building 2D item to be updated\. This value can be null\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string)'></a>

## Building2DController\.UpdateItemsAsync\(JsonArray, string\) Method

Updates multiple building 2D items\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemsAsync(System.Text.Json.Nodes.JsonArray? jsonArray, string? code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the building 2D items to be updated\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

An optional code used for the update operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter'></a>

## Building2DReferencesByPagingParameter Class

Parameter class containing options for keyset\-paginated building 2D reference queries\.

```csharp
public class Building2DReferencesByPagingParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → Building2DReferencesByPagingParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.Building2DReferencesByPagingParameter()'></a>

## Building2DReferencesByPagingParameter\(\) Constructor

Initializes a new instance of the [Building2DReferencesByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.Building2DReferencesByPagingParameter') class\.

```csharp
public Building2DReferencesByPagingParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.Building2DReferencesByPagingParameter(DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter)'></a>

## Building2DReferencesByPagingParameter\(Building2DReferencesByPagingParameter\) Constructor

Initializes a new instance of the [Building2DReferencesByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.Building2DReferencesByPagingParameter') class by copying properties from another instance\.

```csharp
public Building2DReferencesByPagingParameter(DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter building2DReferencesByPagingParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.Building2DReferencesByPagingParameter(DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter).building2DReferencesByPagingParameter'></a>

`building2DReferencesByPagingParameter` [Building2DReferencesByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.Building2DReferencesByPagingParameter')

The parameter instance to copy properties from\.

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.Building2DReferencesByPagingParameter(System.Text.Json.Nodes.JsonObject)'></a>

## Building2DReferencesByPagingParameter\(JsonObject\) Constructor

Initializes a new instance of the [Building2DReferencesByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.Building2DReferencesByPagingParameter') class using a [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public Building2DReferencesByPagingParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.Building2DReferencesByPagingParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.CountyId'></a>

## Building2DReferencesByPagingParameter\.CountyId Property

Gets or sets the target partition identifier \(County ID\)\.

```csharp
public int CountyId { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
10365

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.Cursor'></a>

## Building2DReferencesByPagingParameter\.Cursor Property

Gets or sets the pagination cursor tracking the last processed building reference\.

```csharp
public string? Cursor { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Example
BLDG\-12345

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.PageSize'></a>

## Building2DReferencesByPagingParameter\.PageSize Property

Gets or sets the maximum count of references per page\. Defaults to 250\.

```csharp
public int PageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
100

<a name='DiGi.GIS.WebAPI.Classes.Building2DReferencesByPagingParameter.SubdivisionId'></a>

## Building2DReferencesByPagingParameter\.SubdivisionId Property

Gets or sets the target subdivision identifier \(Subdivision ID\)\.

```csharp
public int SubdivisionId { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
1035

<a name='DiGi.GIS.WebAPI.Classes.Building2DsPostTask'></a>

## Building2DsPostTask Class

Provides functionality to handle the asynchronous posting of multiple [DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D') objects to the GIS PostgreSQL database\.

```csharp
public class Building2DsPostTask : DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask<DiGi.GIS.Classes.Building2D>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.GIS\.Classes\.Building2D](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.building2d 'DiGi\.GIS\.Classes\.Building2D')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → Building2DsPostTask
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.Building2DsPostTask.Building2DsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## Building2DsPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the Building2DsPostTask class\.

```csharp
public Building2DsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.Building2DsPostTask.Building2DsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') used to manage PostgreSQL GIS operations\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.Building2DsPostTask.Code'></a>

## Building2DsPostTask\.Code Property

Gets or sets the code associated with the building 2D post task\.

```csharp
public string? Code { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter'></a>

## BuildingDataByFilterGroupParameter Class

Parameter class containing options for building data queries using dynamic hierarchical filters\.

```csharp
public class BuildingDataByFilterGroupParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → BuildingDataByFilterGroupParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter.BuildingDataByFilterGroupParameter()'></a>

## BuildingDataByFilterGroupParameter\(\) Constructor

Initializes a new instance of the [BuildingDataByFilterGroupParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByFilterGroupParameter') class\.

```csharp
public BuildingDataByFilterGroupParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter.BuildingDataByFilterGroupParameter(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingDataByFilterGroupParameter\(JsonObject\) Constructor

Initializes a new instance of the [BuildingDataByFilterGroupParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByFilterGroupParameter') class using an [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public BuildingDataByFilterGroupParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter.BuildingDataByFilterGroupParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter.ColumnUniqueIds'></a>

## BuildingDataByFilterGroupParameter\.ColumnUniqueIds Property

Gets or sets the optional list of column unique identifiers to project in the result\.

```csharp
public System.Collections.Generic.List<string>? ColumnUniqueIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter.FilterGroup'></a>

## BuildingDataByFilterGroupParameter\.FilterGroup Property

Gets or sets the dynamic hierarchical filter group to apply to the database query\.

```csharp
public DiGi.PostgreSQL.Table.Classes.FilterGroup FilterGroup { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.filtergroup 'DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter'></a>

## BuildingDataByPagingParameter Class

Parameter class containing options for keyset\-paginated building queries\.

```csharp
public class BuildingDataByPagingParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → BuildingDataByPagingParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.BuildingDataByPagingParameter()'></a>

## BuildingDataByPagingParameter\(\) Constructor

Initializes a new instance of the [BuildingDataByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByPagingParameter') class\.

```csharp
public BuildingDataByPagingParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.BuildingDataByPagingParameter(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingDataByPagingParameter\(JsonObject\) Constructor

Initializes a new instance of the [BuildingDataByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByPagingParameter') class using an [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public BuildingDataByPagingParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.BuildingDataByPagingParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.ColumnUniqueIds'></a>

## BuildingDataByPagingParameter\.ColumnUniqueIds Property

Gets or sets the list of column unique identifiers to project in the result\.

```csharp
public System.Collections.Generic.List<string>? ColumnUniqueIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

### Example
\["building\_id", "address"\]

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.CountyId'></a>

## BuildingDataByPagingParameter\.CountyId Property

Gets or sets the target partition identifier \(County ID\)\.

```csharp
public int CountyId { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
10365

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.Cursor'></a>

## BuildingDataByPagingParameter\.Cursor Property

Gets or sets the pagination cursor tracking the last processed building reference\.

```csharp
public string? Cursor { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Example
eyJpZCI6MTIzfQ==

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter.PageSize'></a>

## BuildingDataByPagingParameter\.PageSize Property

Gets or sets the maximum count of rows per page\. Defaults to 250\.

```csharp
public int PageSize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
100

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter'></a>

## BuildingDataByReferencesParameter Class

Represents a parameter containing references for querying building data\.

```csharp
public class BuildingDataByReferencesParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → BuildingDataByReferencesParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.BuildingDataByReferencesParameter()'></a>

## BuildingDataByReferencesParameter\(\) Constructor

Initializes a new instance of the [BuildingDataByReferencesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByReferencesParameter') class\.

```csharp
public BuildingDataByReferencesParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.BuildingDataByReferencesParameter(DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter)'></a>

## BuildingDataByReferencesParameter\(BuildingDataByReferencesParameter\) Constructor

Initializes a new instance of the [BuildingDataByReferencesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByReferencesParameter') class using an existing [BuildingDataByReferencesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByReferencesParameter') object\.

```csharp
public BuildingDataByReferencesParameter(DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter buildingDataByReferencesParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.BuildingDataByReferencesParameter(DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter).buildingDataByReferencesParameter'></a>

`buildingDataByReferencesParameter` [BuildingDataByReferencesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByReferencesParameter')

The parameter object to copy data from\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.BuildingDataByReferencesParameter(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingDataByReferencesParameter\(JsonObject\) Constructor

Initializes a new instance of the [BuildingDataByReferencesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByReferencesParameter') class using a JSON object\.

```csharp
public BuildingDataByReferencesParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.BuildingDataByReferencesParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing parameter data\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.ColumnUniqueIds'></a>

## BuildingDataByReferencesParameter\.ColumnUniqueIds Property

Gets or sets the unique identifiers of the columns \(Column\.UniqueId\)\. All columns will be returned if the collection is null or empty\.
Required if performance is a concern and the column unique identifiers are available; otherwise, the column unique identifiers will be determined by the building data PostgreSQL converter\.

```csharp
public System.Collections.Generic.IEnumerable<string> ColumnUniqueIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.CountyId'></a>

## BuildingDataByReferencesParameter\.CountyId Property

Gets or sets the county identifier\.
Required if performance is a concern and the county identifier is available; otherwise, the county identifier will be determined by the building data PostgreSQL converter\.

```csharp
public System.Nullable<int> CountyId { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter.References'></a>

## BuildingDataByReferencesParameter\.References Property

Gets or sets the references for the building data parameter\.

```csharp
public System.Collections.Generic.IEnumerable<string> References { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter'></a>

## BuildingDataBySubdivisionIdsParameter Class

Represents a parameter containing subdivision ids for querying building data\.

```csharp
public class BuildingDataBySubdivisionIdsParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → BuildingDataBySubdivisionIdsParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.BuildingDataBySubdivisionIdsParameter()'></a>

## BuildingDataBySubdivisionIdsParameter\(\) Constructor

Initializes a new instance of the [BuildingDataBySubdivisionIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataBySubdivisionIdsParameter') class\.

```csharp
public BuildingDataBySubdivisionIdsParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.BuildingDataBySubdivisionIdsParameter(DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter)'></a>

## BuildingDataBySubdivisionIdsParameter\(BuildingDataBySubdivisionIdsParameter\) Constructor

Initializes a new instance of the [BuildingDataBySubdivisionIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataBySubdivisionIdsParameter') class using an existing [BuildingDataBySubdivisionIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataBySubdivisionIdsParameter') object\.

```csharp
public BuildingDataBySubdivisionIdsParameter(DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter buildingDataBySubdivisionIdsParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.BuildingDataBySubdivisionIdsParameter(DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter).buildingDataBySubdivisionIdsParameter'></a>

`buildingDataBySubdivisionIdsParameter` [BuildingDataBySubdivisionIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataBySubdivisionIdsParameter')

The parameter object to copy data from\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.BuildingDataBySubdivisionIdsParameter(System.Text.Json.Nodes.JsonObject)'></a>

## BuildingDataBySubdivisionIdsParameter\(JsonObject\) Constructor

Initializes a new instance of the [BuildingDataBySubdivisionIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataBySubdivisionIdsParameter') class using a JSON object\.

```csharp
public BuildingDataBySubdivisionIdsParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.BuildingDataBySubdivisionIdsParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing parameter data\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.ColumnUniqueIds'></a>

## BuildingDataBySubdivisionIdsParameter\.ColumnUniqueIds Property

Gets or sets the unique identifiers of the columns \(Column\.UniqueId\)\. All columns will be returned if the collection is null or empty\.
Required if performance is a concern and the column unique identifiers are available; otherwise, the column unique identifiers will be determined by the building data PostgreSQL converter\.

```csharp
public System.Collections.Generic.IEnumerable<string> ColumnUniqueIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter.SubdivisionIds'></a>

## BuildingDataBySubdivisionIdsParameter\.SubdivisionIds Property

Gets or sets the subdivision ids for the building data

```csharp
public System.Collections.Generic.IEnumerable<int> SubdivisionIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController'></a>

## BuildingDataController Class

Controller responsible for handling API requests related to building data retrieved from a PostgreSQL database\.

```csharp
public class BuildingDataController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → BuildingDataController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.BuildingDataController(DiGi.GIS.PostgreSQL.Classes.BuildingDataPostgreSQLConverter)'></a>

## BuildingDataController\(BuildingDataPostgreSQLConverter\) Constructor

Initializes a new instance of the BuildingDataController class\.

```csharp
public BuildingDataController(DiGi.GIS.PostgreSQL.Classes.BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.BuildingDataController(DiGi.GIS.PostgreSQL.Classes.BuildingDataPostgreSQLConverter).buildingDataPostgreSQLConverter'></a>

`buildingDataPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.BuildingDataPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.buildingdatapostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.BuildingDataPostgreSQLConverter')

The [DiGi\.GIS\.PostgreSQL\.Classes\.BuildingDataPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.buildingdatapostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.BuildingDataPostgreSQLConverter') used to handle building data operations and database conversions\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetCategoriesAsync()'></a>

## BuildingDataController\.GetCategoriesAsync\(\) Method

Asynchronously retrieves all available building data column categories\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetCategoriesAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnReferencesAsync(System.Collections.Generic.List_string_)'></a>

## BuildingDataController\.GetColumnReferencesAsync\(List\<string\>\) Method

Asynchronously retrieves all column references, optionally filtered by the specified categories\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetColumnReferencesAsync(System.Collections.Generic.List<string>? categories=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnReferencesAsync(System.Collections.Generic.List_string_).categories'></a>

`categories` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

An optional list of category names to filter the column references by\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning a list of column references\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnsAsync()'></a>

## BuildingDataController\.GetColumnsAsync\(\) Method

Asynchronously retrieves all available column definitions for building data\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetColumnsAsync();
```

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnsByCategoriesAsync(System.Collections.Generic.List_string_)'></a>

## BuildingDataController\.GetColumnsByCategoriesAsync\(List\<string\>\) Method

Asynchronously retrieves all columns filtered by the specified categories\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetColumnsByCategoriesAsync(System.Collections.Generic.List<string>? categories=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnsByCategoriesAsync(System.Collections.Generic.List_string_).categories'></a>

`categories` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

An optional list of category names to filter the columns by\. If null, the filtering behavior is determined by the underlying data source\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnsByCategoriesParameterAsync(DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter)'></a>

## BuildingDataController\.GetColumnsByCategoriesParameterAsync\(ColumnsByCategoriesParameter\) Method

Retrieves all columns with given categories by columns by categories parameter \(which contains categories\)\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetColumnsByCategoriesParameterAsync(DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter columnsByCategoriesParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnsByCategoriesParameterAsync(DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter).columnsByCategoriesParameter'></a>

`columnsByCategoriesParameter` [ColumnsByCategoriesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter 'DiGi\.GIS\.WebAPI\.Classes\.ColumnsByCategoriesParameter')

The parameter containing the categories for querying columns\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
Column [DiGi\.PostgreSQL\.Table\.Classes\.Column](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.column 'DiGi\.PostgreSQL\.Table\.Classes\.Column')

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnUniqueIdsAsync(System.Collections.Generic.List_string_)'></a>

## BuildingDataController\.GetColumnUniqueIdsAsync\(List\<string\>\) Method

Retrieves the unique identifiers for columns, optionally filtered by the specified categories\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetColumnUniqueIdsAsync(System.Collections.Generic.List<string>? categories=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetColumnUniqueIdsAsync(System.Collections.Generic.List_string_).categories'></a>

`categories` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

An optional list of category names used to filter the column references\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetHistogramSummaryAsync(DiGi.GIS.WebAPI.Classes.HistogramRequestParameter)'></a>

## BuildingDataController\.GetHistogramSummaryAsync\(HistogramRequestParameter\) Method

Generates a value range distribution histogram for a specific building data column inside a county partition, applying optional dynamic filters\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetHistogramSummaryAsync(DiGi.GIS.WebAPI.Classes.HistogramRequestParameter histogramRequestParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetHistogramSummaryAsync(DiGi.GIS.WebAPI.Classes.HistogramRequestParameter).histogramRequestParameter'></a>

`histogramRequestParameter` [HistogramRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.HistogramRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.HistogramRequestParameter')

The parameter containing the target column, county identifier, desired bucket count, and optional dynamic filters\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning the histogram bucket list as a JSON array\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetMultivalueAggregateSummaryAsync(DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter)'></a>

## BuildingDataController\.GetMultivalueAggregateSummaryAsync\(MultivalueAggregateRequestParameter\) Method

Computes multi\-value statistical summaries \(SplitDistinctCount, SplitValueDistribution\) on a partition column\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetMultivalueAggregateSummaryAsync(DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter multivalueAggregateRequestParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetMultivalueAggregateSummaryAsync(DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter).multivalueAggregateRequestParameter'></a>

`multivalueAggregateRequestParameter` [MultivalueAggregateRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.MultivalueAggregateRequestParameter')

The parameter containing target column, multi\-value aggregate function, county identifier, and optional separator\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning the aggregate result as a JSON node\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetSinglevalueAggregateSummaryAsync(DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter)'></a>

## BuildingDataController\.GetSinglevalueAggregateSummaryAsync\(SinglevalueAggregateRequestParameter\) Method

Computes single\-value statistical summaries \(Avg, Sum, Min, Max, Count, DistinctCount\) on a partition column\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetSinglevalueAggregateSummaryAsync(DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter singlevalueAggregateRequestParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetSinglevalueAggregateSummaryAsync(DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter).singlevalueAggregateRequestParameter'></a>

`singlevalueAggregateRequestParameter` [SinglevalueAggregateRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.SinglevalueAggregateRequestParameter')

The parameter containing target column, single\-value aggregate function, and county identifier\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning the aggregate result as a JSON node\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByBuildingDataByPagingParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter)'></a>

## BuildingDataController\.GetTableByBuildingDataByPagingParameterAsync\(BuildingDataByPagingParameter\) Method

Retrieves a building data table using keyset\-based paginated cursor streaming\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetTableByBuildingDataByPagingParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter buildingDataByPagingParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByBuildingDataByPagingParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter).buildingDataByPagingParameter'></a>

`buildingDataByPagingParameter` [BuildingDataByPagingParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByPagingParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByPagingParameter')

The parameter containing paging options, including column projections, county identifier, cursor, and page size\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning the populated table\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByBuildingDataByReferencesParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter)'></a>

## BuildingDataController\.GetTableByBuildingDataByReferencesParameterAsync\(BuildingDataByReferencesParameter\) Method

Retrieves a building data table by building data by references parameter \(column unique ids, county id and references\)\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetTableByBuildingDataByReferencesParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter buildingDataByReferencesParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByBuildingDataByReferencesParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter).buildingDataByReferencesParameter'></a>

`buildingDataByReferencesParameter` [BuildingDataByReferencesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByReferencesParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByReferencesParameter')

The parameter containing references for querying building data, including column unique identifiers, county identifier, and specific references\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') representing the result of the operation, typically containing a [DiGi\.PostgreSQL\.Table\.Classes\.Table](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.table 'DiGi\.PostgreSQL\.Table\.Classes\.Table') if found\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByBuildingDataBySubdivisionIdsParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter)'></a>

## BuildingDataController\.GetTableByBuildingDataBySubdivisionIdsParameterAsync\(BuildingDataBySubdivisionIdsParameter\) Method

Retrieves a building data table by building data by subdivision ids parameter \(column unique ids, subdivision ids\)\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetTableByBuildingDataBySubdivisionIdsParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter buildingDataBySubdivisionIdsParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByBuildingDataBySubdivisionIdsParameterAsync(DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter).buildingDataBySubdivisionIdsParameter'></a>

`buildingDataBySubdivisionIdsParameter` [BuildingDataBySubdivisionIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataBySubdivisionIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataBySubdivisionIdsParameter')

The parameter containing the subdivision IDs and optional column unique identifiers for querying building data\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByFilterGroupAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter)'></a>

## BuildingDataController\.GetTableByFilterGroupAsync\(BuildingDataByFilterGroupParameter\) Method

Retrieves a building data table filtered by the specified dynamic hierarchical filters\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetTableByFilterGroupAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter buildingDataByFilterGroupParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByFilterGroupAsync(DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter).buildingDataByFilterGroupParameter'></a>

`buildingDataByFilterGroupParameter` [BuildingDataByFilterGroupParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingDataByFilterGroupParameter 'DiGi\.GIS\.WebAPI\.Classes\.BuildingDataByFilterGroupParameter')

The parameter containing the dynamic filter group and optional column unique identifiers\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning the populated filtered table\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByReferenceAsync(string,System.Nullable_int_)'></a>

## BuildingDataController\.GetTableByReferenceAsync\(string, Nullable\<int\>\) Method

Retrieves a building data table for one specific building\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetTableByReferenceAsync(string reference, System.Nullable<int> countyId=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByReferenceAsync(string,System.Nullable_int_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

Building reference

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetTableByReferenceAsync(string,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The unique identifier of the county for which building belongs to\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task representing the asynchronous operation, returning the populated filtered table with data for sigle building\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetUniqueValuesAsync(string,System.Nullable_int_)'></a>

## BuildingDataController\.GetUniqueValuesAsync\(string, Nullable\<int\>\) Method

Retrieves unique values for a specified column unique identifier and an optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetUniqueValuesAsync(string columnUniqueId, System.Nullable<int> countyId=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetUniqueValuesAsync(string,System.Nullable_int_).columnUniqueId'></a>

`columnUniqueId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier of the column from which to retrieve unique values\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetUniqueValuesAsync(string,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional integer identifier of the county used to filter the results\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetUniqueValuesByColumnUniqueIdParameterAsync(DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter)'></a>

## BuildingDataController\.GetUniqueValuesByColumnUniqueIdParameterAsync\(UniqueValuesByColumnUniqueIdParameter\) Method

Retrieves unique values for a given [UniqueValuesByColumnUniqueIdParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter 'DiGi\.GIS\.WebAPI\.Classes\.UniqueValuesByColumnUniqueIdParameter') \(column unique id and optionally county id\), applying optional dynamic filters\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetUniqueValuesByColumnUniqueIdParameterAsync(DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter uniqueValuesByColumnUniqueIdParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingDataController.GetUniqueValuesByColumnUniqueIdParameterAsync(DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter).uniqueValuesByColumnUniqueIdParameter'></a>

`uniqueValuesByColumnUniqueIdParameter` [UniqueValuesByColumnUniqueIdParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter 'DiGi\.GIS\.WebAPI\.Classes\.UniqueValuesByColumnUniqueIdParameter')

The parameter containing the column unique identifier, optional county identifier, and optional dynamic filters\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') representing the result of the operation, typically a list of unique values or a not found status\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController'></a>

## BuildingModelController Class

Web API controller for building model operations, providing endpoints to retrieve building model data\.

```csharp
public class BuildingModelController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → BuildingModelController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.BuildingModelController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter)'></a>

## BuildingModelController\(GISWebAPIConfigurationFileWatcher, Building2DPostgreSQLConverter\) Constructor

Initializes a new instance of the [BuildingModelController](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.BuildingModelController 'DiGi\.GIS\.WebAPI\.Classes\.BuildingModelController') class\.

```csharp
public BuildingModelController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.BuildingModelController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher for the GIS PostgreSQL Web API\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.BuildingModelController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter).building2DPostgreSQLConverter'></a>

`building2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter')

The converter used for Building 2D data operations in PostgreSQL\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_)'></a>

## BuildingModelController\.GetItemsByCircleAsync\(double, double, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>, Nullable\<double\>\) Method

Retrieves building models within a specified circle\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByCircleAsync(double x, double y, System.Nullable<double> radius, System.Nullable<double> diameter, System.Nullable<double> storeyHeight=3.0, System.Nullable<double> tolerance=1E-06);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X\-coordinate of the center point of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y\-coordinate of the center point of the search circle\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).radius'></a>

`radius` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The radius of the search circle\. This value can be null\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).diameter'></a>

`diameter` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The diameter of the search circle\. This value can be null\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).storeyHeight'></a>

`storeyHeight` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional storey height used for generating building models\. If not provided, a default value of 3\.0 is used\.

<a name='DiGi.GIS.WebAPI.Classes.BuildingModelController.GetItemsByCircleAsync(double,double,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_,System.Nullable_double_).tolerance'></a>

`tolerance` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional tolerance value for the spatial query\. If not provided, the default distance tolerance is used\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter'></a>

## ColumnsByCategoriesParameter Class

Represents a parameter containing categories for querying columns\.

```csharp
public class ColumnsByCategoriesParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → ColumnsByCategoriesParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter.ColumnsByCategoriesParameter()'></a>

## ColumnsByCategoriesParameter\(\) Constructor

Initializes a new instance of the [ColumnsByCategoriesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter 'DiGi\.GIS\.WebAPI\.Classes\.ColumnsByCategoriesParameter') class\.

```csharp
public ColumnsByCategoriesParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter.ColumnsByCategoriesParameter(System.Collections.Generic.IEnumerable_string_)'></a>

## ColumnsByCategoriesParameter\(IEnumerable\<string\>\) Constructor

Initializes a new instance of the [ColumnsByCategoriesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter 'DiGi\.GIS\.WebAPI\.Classes\.ColumnsByCategoriesParameter') class with the specified categories\.

```csharp
public ColumnsByCategoriesParameter(System.Collections.Generic.IEnumerable<string> categories);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter.ColumnsByCategoriesParameter(System.Collections.Generic.IEnumerable_string_).categories'></a>

`categories` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of categories for querying columns\.

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter.ColumnsByCategoriesParameter(System.Text.Json.Nodes.JsonObject)'></a>

## ColumnsByCategoriesParameter\(JsonObject\) Constructor

Initializes a new instance of the [ColumnsByCategoriesParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter 'DiGi\.GIS\.WebAPI\.Classes\.ColumnsByCategoriesParameter') class using an [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public ColumnsByCategoriesParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter.ColumnsByCategoriesParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.ColumnsByCategoriesParameter.Categories'></a>

## ColumnsByCategoriesParameter\.Categories Property

Gets or sets the categories for querying columns\. All columns will be returned if the collection is null or empty\.

```csharp
public System.Collections.Generic.IEnumerable<string> Categories { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter'></a>

## CountByAdministrativeAreal2DIdsParameter Class

Represents a parameter object used to perform counting operations based on a collection of administrative areal 2D identifiers\.

```csharp
public class CountByAdministrativeAreal2DIdsParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → CountByAdministrativeAreal2DIdsParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter.CountByAdministrativeAreal2DIdsParameter()'></a>

## CountByAdministrativeAreal2DIdsParameter\(\) Constructor

Initializes a new instance of the [CountByAdministrativeAreal2DIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.CountByAdministrativeAreal2DIdsParameter') class\.

```csharp
public CountByAdministrativeAreal2DIdsParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter.CountByAdministrativeAreal2DIdsParameter(DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter)'></a>

## CountByAdministrativeAreal2DIdsParameter\(CountByAdministrativeAreal2DIdsParameter\) Constructor

Initializes a new instance of the [CountByAdministrativeAreal2DIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.CountByAdministrativeAreal2DIdsParameter') class by copying the values from an existing instance\.

```csharp
public CountByAdministrativeAreal2DIdsParameter(DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter countByAdministrativeAreal2DIdsParameter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter.CountByAdministrativeAreal2DIdsParameter(DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter).countByAdministrativeAreal2DIdsParameter'></a>

`countByAdministrativeAreal2DIdsParameter` [CountByAdministrativeAreal2DIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.CountByAdministrativeAreal2DIdsParameter')

The source instance from which to copy the administrative areal 2D identifiers\.

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter.CountByAdministrativeAreal2DIdsParameter(System.Text.Json.Nodes.JsonObject)'></a>

## CountByAdministrativeAreal2DIdsParameter\(JsonObject\) Constructor

Initializes a new instance of the [CountByAdministrativeAreal2DIdsParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter 'DiGi\.GIS\.WebAPI\.Classes\.CountByAdministrativeAreal2DIdsParameter') class using the provided JSON object\.

```csharp
public CountByAdministrativeAreal2DIdsParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter.CountByAdministrativeAreal2DIdsParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.CountByAdministrativeAreal2DIdsParameter.AdministrativeAreal2DIds'></a>

## CountByAdministrativeAreal2DIdsParameter\.AdministrativeAreal2DIds Property

Gets or sets the collection of administrative areal 2D identifiers used for counting operations\.

```csharp
public System.Collections.Generic.IEnumerable<int> AdministrativeAreal2DIds { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController'></a>

## EPWFileController Class

Controller responsible for handling API requests related to EPW files retrieved from or updated in a PostgreSQL database\.

```csharp
public class EPWFileController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → EPWFileController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.EPWFileController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.EPWFilePostgreSQLConverter)'></a>

## EPWFileController\(GISWebAPIConfigurationFileWatcher, EPWFilePostgreSQLConverter\) Constructor

Initializes a new instance of the [EPWFileController](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.EPWFileController 'DiGi\.GIS\.WebAPI\.Classes\.EPWFileController') class\.

```csharp
public EPWFileController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.EPWFilePostgreSQLConverter ePWFilePostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.EPWFileController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.EPWFilePostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher used to monitor changes to the GIS PostgreSQL Web API settings\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.EPWFileController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.EPWFilePostgreSQLConverter).ePWFilePostgreSQLConverter'></a>

`ePWFilePostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.EPWFilePostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.epwfilepostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.EPWFilePostgreSQLConverter')

The converter used for handling EPW file operations within the PostgreSQL database\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.GetEPWFileAsync(double,double,System.Threading.CancellationToken)'></a>

## EPWFileController\.GetEPWFileAsync\(double, double, CancellationToken\) Method

Asynchronously retrieves the closest EPWFile to the given coordinate \(x, y\)\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetEPWFileAsync(double x, double y, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.GetEPWFileAsync(double,double,System.Threading.CancellationToken).x'></a>

`x` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The X coordinate \(longitude\)\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.GetEPWFileAsync(double,double,System.Threading.CancellationToken).y'></a>

`y` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The Y coordinate \(latitude\)\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.GetEPWFileAsync(double,double,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used by the caller to cancel the asynchronous operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,System.Threading.CancellationToken)'></a>

## EPWFileController\.UpdateItemsAsync\(JsonArray, CancellationToken\) Method

Asynchronously updates or inserts a collection of EPW files\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemsAsync(System.Text.Json.Nodes.JsonArray? jsonArray, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,System.Threading.CancellationToken).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the EPW files to update or insert\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFileController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used by the caller to cancel the asynchronous operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask'></a>

## EPWFilesPostTask Class

Provides functionality to handle the asynchronous posting of multiple [DiGi\.EPW\.Classes\.EPWFile](https://learn.microsoft.com/en-us/dotnet/api/digi.epw.classes.epwfile 'DiGi\.EPW\.Classes\.EPWFile') objects to the GIS PostgreSQL database\.

```csharp
public class EPWFilesPostTask : DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask<DiGi.EPW.Classes.EPWFile>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.EPW\.Classes\.EPWFile](https://learn.microsoft.com/en-us/dotnet/api/digi.epw.classes.epwfile 'DiGi\.EPW\.Classes\.EPWFile')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → EPWFilesPostTask
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.EPWFilesPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## EPWFilesPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the [EPWFilesPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.EPWFilesPostTask 'DiGi\.GIS\.WebAPI\.Classes\.EPWFilesPostTask') class\.

```csharp
public EPWFilesPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.EPWFilesPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager') used to manage PostgreSQL GIS operations\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.Core.Classes.LongProgressWrapper,System.Threading.CancellationToken)'></a>

## EPWFilesPostTask\.ExecuteAsync\(IEnumerable\<EPWFile\>, LongProgressWrapper, CancellationToken\) Method

Asynchronously executes the posting of EPW files\.

```csharp
protected System.Threading.Tasks.Task<bool> ExecuteAsync(System.Collections.Generic.IEnumerable<DiGi.EPW.Classes.EPWFile>? ePWFiles, DiGi.Core.Classes.LongProgressWrapper? longProgressWrapper, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.Core.Classes.LongProgressWrapper,System.Threading.CancellationToken).ePWFiles'></a>

`ePWFiles` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.EPW\.Classes\.EPWFile](https://learn.microsoft.com/en-us/dotnet/api/digi.epw.classes.epwfile 'DiGi\.EPW\.Classes\.EPWFile')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of EPW files to post\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.Core.Classes.LongProgressWrapper,System.Threading.CancellationToken).longProgressWrapper'></a>

`longProgressWrapper` [DiGi\.Core\.Classes\.LongProgressWrapper](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.longprogresswrapper 'DiGi\.Core\.Classes\.LongProgressWrapper')

The progress wrapper to track the number of posted files\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.Collections.Generic.IEnumerable_DiGi.EPW.Classes.EPWFile_,DiGi.Core.Classes.LongProgressWrapper,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the post succeeded; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken)'></a>

## EPWFilesPostTask\.ExecuteAsync\(IProgress\<long\>, CancellationToken\) Method

Asynchronously executes the background task, reporting progress\.

```csharp
protected override System.Threading.Tasks.Task<bool> ExecuteAsync(System.IProgress<long> progress, System.Threading.CancellationToken cancellationToken);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).progress'></a>

`progress` [System\.IProgress&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iprogress-1 'System\.IProgress\`1')

The progress reporter for reporting progress updates\.

<a name='DiGi.GIS.WebAPI.Classes.EPWFilesPostTask.ExecuteAsync(System.IProgress_long_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The cancellation token to cancel the operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation, returning [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool') if the operation succeeded; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/builtin\-types/bool')\.

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher'></a>

## GISWebAPIConfigurationFileWatcher Class

Provides functionality to watch and retrieve configuration settings for the GIS PostgreSQL Web API from a specified configuration file\.

```csharp
public class GISWebAPIConfigurationFileWatcher : DiGi.Core.IO.FileWatcher.Classes.ConfigurationFileWatcher
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.IO\.FileWatcher\.Classes\.FileWatcher](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.filewatcher.classes.filewatcher 'DiGi\.Core\.IO\.FileWatcher\.Classes\.FileWatcher') → [DiGi\.Core\.IO\.FileWatcher\.Classes\.ConfigurationFileWatcher](https://learn.microsoft.com/en-us/dotnet/api/digi.core.io.filewatcher.classes.configurationfilewatcher 'DiGi\.Core\.IO\.FileWatcher\.Classes\.ConfigurationFileWatcher') → GISWebAPIConfigurationFileWatcher
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.GISWebAPIConfigurationFileWatcher(string,double)'></a>

## GISWebAPIConfigurationFileWatcher\(string, double\) Constructor

Initializes a new instance of the GISWebAPIConfigurationFileWatcher class\.

```csharp
public GISWebAPIConfigurationFileWatcher(string path, double interval=5000.0);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.GISWebAPIConfigurationFileWatcher(string,double).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path to the configuration file to be watched\.

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.GISWebAPIConfigurationFileWatcher(string,double).interval'></a>

`interval` [System\.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double 'System\.Double')

The time interval in milliseconds between checks for changes to the configuration file\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.AllowUpdateAdministrativeAreal2D'></a>

## GISWebAPIConfigurationFileWatcher\.AllowUpdateAdministrativeAreal2D Property

Gets a value indicating whether updates to administrative areal 2D data are permitted according to the configuration file\.

```csharp
public bool AllowUpdateAdministrativeAreal2D { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.AllowUpdateBuilding2D'></a>

## GISWebAPIConfigurationFileWatcher\.AllowUpdateBuilding2D Property

Gets a value indicating whether updates to 2D buildings are permitted based on the configuration file settings\.

```csharp
public bool AllowUpdateBuilding2D { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.AllowUpdateEPWFile'></a>

## GISWebAPIConfigurationFileWatcher\.AllowUpdateEPWFile Property

Gets a value indicating whether updating EPW file data is enabled in the configuration\.

```csharp
public bool AllowUpdateEPWFile { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.AllowUpdateOrtoDatas'></a>

## GISWebAPIConfigurationFileWatcher\.AllowUpdateOrtoDatas Property

Gets a value indicating whether updates to orthophoto data are permitted according to the configuration file\.

```csharp
public bool AllowUpdateOrtoDatas { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher.AllowUpdateYearBuiltData'></a>

## GISWebAPIConfigurationFileWatcher\.AllowUpdateYearBuiltData Property

Gets a value indicating whether updating year built data is enabled in the configuration\.

```csharp
public bool AllowUpdateYearBuiltData { get; }
```

#### Property Value
[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager'></a>

## GISWebAPIManager Class

Manages the creation and lifecycle of [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') instances used to interact with the GIS PostgreSQL Web API\.

```csharp
public class GISWebAPIManager
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → GISWebAPIManager
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.GISWebAPIManager(System.Net.Http.IHttpClientFactory)'></a>

## GISWebAPIManager\(IHttpClientFactory\) Constructor

Initializes a new instance of the GISWebAPIManager class\.

```csharp
public GISWebAPIManager(System.Net.Http.IHttpClientFactory? httpClientFactory);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.GISWebAPIManager(System.Net.Http.IHttpClientFactory).httpClientFactory'></a>

`httpClientFactory` [System\.Net\.Http\.IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.ihttpclientfactory 'System\.Net\.Http\.IHttpClientFactory')

The HTTP client factory used to create and manage [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') instances\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient(string)'></a>

## GISWebAPIManager\.CreateHttpClient\(string\) Method

Creates an HttpClient instance with the specified name\.

```csharp
public System.Net.Http.HttpClient? CreateHttpClient(string name);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient(string).name'></a>

`name` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier or name of the HTTP client to be created\.

#### Returns
[System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string)'></a>

## GISWebAPIManager\.CreateHttpClient\<TControllerBase\>\(string\) Method

Creates an [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') instance configured for the Web API, resolving the route associated with the specified controller type\.

```csharp
public System.Net.Http.HttpClient? CreateHttpClient<TControllerBase>(out string? route)
    where TControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string).TControllerBase'></a>

`TControllerBase`

The TControllerBase type parameter\.
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string).route'></a>

`route` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The route\.

#### Returns
[System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string,string)'></a>

## GISWebAPIManager\.CreateHttpClient\<TControllerBase\>\(string, string\) Method

Creates an [System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient') instance configured for the specified controller's method and retrieves the corresponding API path\.

```csharp
public System.Net.Http.HttpClient? CreateHttpClient<TControllerBase>(string methodName, out string? path)
    where TControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase;
```
#### Type parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string,string).TControllerBase'></a>

`TControllerBase`

The type of the base controller used to resolve the endpoint path\.
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string,string).methodName'></a>

`methodName` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The name of the method within the controller to resolve\.

<a name='DiGi.GIS.WebAPI.Classes.GISWebAPIManager.CreateHttpClient_TControllerBase_(string,string).path'></a>

`path` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The path\.

#### Returns
[System\.Net\.Http\.HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient 'System\.Net\.Http\.HttpClient')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.HeatTransferCoefficientController'></a>

## HeatTransferCoefficientController Class

Controller responsible for handling API requests related to heat transfer coefficients, providing access to regulated heat transfer coefficient data\.

```csharp
public class HeatTransferCoefficientController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → HeatTransferCoefficientController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.HeatTransferCoefficientController.HeatTransferCoefficientController()'></a>

## HeatTransferCoefficientController\(\) Constructor

Initializes a new instance of the HeatTransferCoefficientController class\.

```csharp
public HeatTransferCoefficientController();
```
### Methods

<a name='DiGi.GIS.WebAPI.Classes.HeatTransferCoefficientController.GetRegulatedHeatTransferCoefficientsByYearAsync(short,System.Threading.CancellationToken)'></a>

## HeatTransferCoefficientController\.GetRegulatedHeatTransferCoefficientsByYearAsync\(short, CancellationToken\) Method

Retrieves the regulated heat transfer coefficients for a specified year\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetRegulatedHeatTransferCoefficientsByYearAsync(short year, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.HeatTransferCoefficientController.GetRegulatedHeatTransferCoefficientsByYearAsync(short,System.Threading.CancellationToken).year'></a>

`year` [System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')

The year used to filter the regulated heat transfer coefficients\.

<a name='DiGi.GIS.WebAPI.Classes.HeatTransferCoefficientController.GetRegulatedHeatTransferCoefficientsByYearAsync(short,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used by the caller to cancel the asynchronous operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') representing the result of the request, containing the retrieved coefficients or an error status\.

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter'></a>

## HistogramRequestParameter Class

Parameter class containing options for generating histograms\.

```csharp
public class HistogramRequestParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → HistogramRequestParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.HistogramRequestParameter()'></a>

## HistogramRequestParameter\(\) Constructor

Initializes a new instance of the [HistogramRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.HistogramRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.HistogramRequestParameter') class\.

```csharp
public HistogramRequestParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.HistogramRequestParameter(System.Text.Json.Nodes.JsonObject)'></a>

## HistogramRequestParameter\(JsonObject\) Constructor

Initializes a new instance of the [HistogramRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.HistogramRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.HistogramRequestParameter') class using an [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public HistogramRequestParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.HistogramRequestParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.BucketCount'></a>

## HistogramRequestParameter\.BucketCount Property

Gets or sets the total number of histogram buckets\. Defaults to 10\.

```csharp
public int BucketCount { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
20

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.ColumnUniqueId'></a>

## HistogramRequestParameter\.ColumnUniqueId Property

Gets or sets the column unique identifier to calculate value distributions for\.

```csharp
public string ColumnUniqueId { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Example
"column\_unique\_id\_123"

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.CountyId'></a>

## HistogramRequestParameter\.CountyId Property

Gets or sets the target partition identifier \(County ID\)\.

```csharp
public int CountyId { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
10365

<a name='DiGi.GIS.WebAPI.Classes.HistogramRequestParameter.FilterGroup'></a>

## HistogramRequestParameter\.FilterGroup Property

Gets or sets the optional dynamic hierarchical filters to apply prior to generating the histogram\.

```csharp
public DiGi.PostgreSQL.Table.Classes.FilterGroup? FilterGroup { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.filtergroup 'DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup')

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter'></a>

## MultivalueAggregateRequestParameter Class

Parameter class containing options for multi\-value database aggregation queries\.

```csharp
public class MultivalueAggregateRequestParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → MultivalueAggregateRequestParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.MultivalueAggregateRequestParameter()'></a>

## MultivalueAggregateRequestParameter\(\) Constructor

Initializes a new instance of the [MultivalueAggregateRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.MultivalueAggregateRequestParameter') class\.

```csharp
public MultivalueAggregateRequestParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.MultivalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject)'></a>

## MultivalueAggregateRequestParameter\(JsonObject\) Constructor

Initializes a new instance of the [MultivalueAggregateRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.MultivalueAggregateRequestParameter') class using a [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public MultivalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.MultivalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.ColumnUniqueId'></a>

## MultivalueAggregateRequestParameter\.ColumnUniqueId Property

Gets or sets the column unique identifier to calculate statistics for\.

```csharp
public string ColumnUniqueId { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Example
"col\_unique\_id\_123"

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.CountyId'></a>

## MultivalueAggregateRequestParameter\.CountyId Property

Gets or sets the target partition identifier \(County ID\)\.

```csharp
public int CountyId { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
10365

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.FilterGroup'></a>

## MultivalueAggregateRequestParameter\.FilterGroup Property

Gets or sets the optional dynamic hierarchical filters to apply prior to aggregation\.

```csharp
public DiGi.PostgreSQL.Table.Classes.FilterGroup? FilterGroup { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.filtergroup 'DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup')

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.MultivalueAggregateFunction'></a>

## MultivalueAggregateRequestParameter\.MultivalueAggregateFunction Property

Gets or sets the multi\-value aggregation function to perform\.

```csharp
public DiGi.PostgreSQL.Table.Enums.MultivalueAggregateFunction MultivalueAggregateFunction { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Enums\.MultivalueAggregateFunction](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.enums.multivalueaggregatefunction 'DiGi\.PostgreSQL\.Table\.Enums\.MultivalueAggregateFunction')

### Example
SplitDistinctCount

<a name='DiGi.GIS.WebAPI.Classes.MultivalueAggregateRequestParameter.Separator'></a>

## MultivalueAggregateRequestParameter\.Separator Property

Gets or sets the optional string separator; defaults to null triggering dynamic auto\-detection\.

```csharp
public string? Separator { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Example
","

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController'></a>

## OccupancyDataController Class

Controller responsible for handling requests related to occupancy data within the GIS PostgreSQL Web API\.

```csharp
public class OccupancyDataController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → OccupancyDataController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.OccupancyDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter)'></a>

## OccupancyDataController\(GISWebAPIConfigurationFileWatcher, Building2DOccupancyDataPostgreSQLConverter, AdministrativeAreal2DOccupancyDataPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter\) Constructor

Initializes a new instance of the OccupancyDataController class\.

```csharp
public OccupancyDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.Building2DOccupancyDataPostgreSQLConverter building2DOccupancyDataPostgreSQLConverter, DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DOccupancyDataPostgreSQLConverter administrativeAreal2DOccupancyDataPostgreSQLConverter, DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.OccupancyDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher used to monitor settings for the GIS PostgreSQL Web API\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.OccupancyDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).building2DOccupancyDataPostgreSQLConverter'></a>

`building2DOccupancyDataPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DOccupancyDataPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2doccupancydatapostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DOccupancyDataPostgreSQLConverter')

The converter used for building 2D occupancy data operations in the PostgreSQL database\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.OccupancyDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).administrativeAreal2DOccupancyDataPostgreSQLConverter'></a>

`administrativeAreal2DOccupancyDataPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DOccupancyDataPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2doccupancydatapostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DOccupancyDataPostgreSQLConverter')

The converter used for administrative areal 2D occupancy data operations in the PostgreSQL database\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.OccupancyDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.Building2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DOccupancyDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).administrativeAreal2DPostgreSQLConverter'></a>

`administrativeAreal2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter')

The converter used for administrative areal 2D data operations in the PostgreSQL database\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.AdministrativeAreal2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray)'></a>

## OccupancyDataController\.AdministrativeAreal2DUpdateItemsAsync\(JsonArray\) Method

Asynchronously updates occupancy data items for administrative areal 2D entities\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> AdministrativeAreal2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray? jsonArray);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.AdministrativeAreal2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray') containing the occupancy data items to be updated\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') representing the result of the update operation, returning a bad request if updates are disabled or no content if the input array is null or empty\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.Building2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string)'></a>

## OccupancyDataController\.Building2DUpdateItemsAsync\(JsonArray, string\) Method

Asynchronously updates building 2D items based on the provided JSON data and identification code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> Building2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray? jsonArray, string code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.Building2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray') containing the item data to be updated\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.Building2DUpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identification code used to validate or categorize the update request\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetAdministrativeAreal2DItemsByReferenceAsync(string,System.Threading.CancellationToken)'></a>

## OccupancyDataController\.GetAdministrativeAreal2DItemsByReferenceAsync\(string, CancellationToken\) Method

Retrieves administrative areal 2D items based on the provided reference identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetAdministrativeAreal2DItemsByReferenceAsync(string reference, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetAdministrativeAreal2DItemsByReferenceAsync(string,System.Threading.CancellationToken).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string used to identify the administrative areal 2D items\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetAdministrativeAreal2DItemsByReferenceAsync(string,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used by the caller to cancel the asynchronous operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') representing the result of the operation, containing the requested items or an error response\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetBuilding2DItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken)'></a>

## OccupancyDataController\.GetBuilding2DItemsByReferenceAsync\(string, Nullable\<int\>, CancellationToken\) Method

Retrieves Building 2D occupancy data items based on a specified reference and an optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetBuilding2DItemsByReferenceAsync(string reference, System.Nullable<int> countyId, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetBuilding2DItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string used to identify the building 2D items\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetBuilding2DItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional identifier of the county associated with the building data\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDataController.GetBuilding2DItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

A cancellation token that can be used by the caller to cancel the asynchronous operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') containing the requested building 2D items, or a [Microsoft\.AspNetCore\.Mvc\.BadRequestResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.badrequestresult 'Microsoft\.AspNetCore\.Mvc\.BadRequestResult') if the reference is null or whitespace\.

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask'></a>

## OccupancyDatasPostTask Class

Represents a task for posting occupancy data to the GIS PostgreSQL Web API\.

```csharp
public class OccupancyDatasPostTask : DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask<DiGi.GIS.Classes.OccupancyData>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → OccupancyDatasPostTask
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask.OccupancyDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## OccupancyDatasPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the OccupancyDatasPostTask class\.

```csharp
public OccupancyDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask.OccupancyDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager used to handle GIS PostgreSQL Web API operations\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask.Code'></a>

## OccupancyDatasPostTask\.Code Property

Gets or sets the code associated with the occupancy data post task\.

```csharp
public string? Code { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask.Values_AdministrativeAreal2D'></a>

## OccupancyDatasPostTask\.Values\_AdministrativeAreal2D Property

Gets or sets the collection of [DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData') values for administrative areal 2D\.

```csharp
public System.Collections.Generic.IEnumerable<DiGi.GIS.Classes.OccupancyData>? Values_AdministrativeAreal2D { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[DiGi\.GIS\.Classes\.OccupancyData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.occupancydata 'DiGi\.GIS\.Classes\.OccupancyData')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController'></a>

## OrtoDatasController Class

Controller providing API endpoints for managing and accessing orthophoto data and related GIS spatial information via a PostgreSQL database\.

```csharp
public class OrtoDatasController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → OrtoDatasController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.OrtoDatasController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.OrtoDatasPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter)'></a>

## OrtoDatasController\(GISWebAPIConfigurationFileWatcher, OrtoDatasPostgreSQLConverter, Building2DPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter\) Constructor

Initializes a new instance of the OrtoDatasController class\.

```csharp
public OrtoDatasController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter, DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter, DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.OrtoDatasController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.OrtoDatasPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher used to monitor changes to the GIS PostgreSQL Web API settings\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.OrtoDatasController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.OrtoDatasPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).ortoDatasPostgreSQLConverter'></a>

`ortoDatasPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.OrtoDatasPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.ortodataspostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.OrtoDatasPostgreSQLConverter')

The converter used for handling OrtoDatas data operations within the PostgreSQL database\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.OrtoDatasController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.OrtoDatasPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).building2DPostgreSQLConverter'></a>

`building2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.building2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.Building2DPostgreSQLConverter')

The converter used for handling Building 2D data operations within the PostgreSQL database\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.OrtoDatasController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.OrtoDatasPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.Building2DPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).administrativeAreal2DPostgreSQLConverter'></a>

`administrativeAreal2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter')

The converter used for handling Administrative Areal 2D data operations within the PostgreSQL database\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.ContainsByReferencesAsync(System.Collections.Generic.List_string_,System.Nullable_int_,System.Nullable_bool_)'></a>

## OrtoDatasController\.ContainsByReferencesAsync\(List\<string\>, Nullable\<int\>, Nullable\<bool\>\) Method

Asynchronously checks for the existence of a collection of references, optionally filtered by a county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> ContainsByReferencesAsync(System.Collections.Generic.List<string>? references, System.Nullable<int> countyId, System.Nullable<bool> inverted);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.ContainsByReferencesAsync(System.Collections.Generic.List_string_,System.Nullable_int_,System.Nullable_bool_).references'></a>

`references` [System\.Collections\.Generic\.List&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1 'System\.Collections\.Generic\.List\`1')

A list of strings representing the references to be checked\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.ContainsByReferencesAsync(System.Collections.Generic.List_string_,System.Nullable_int_,System.Nullable_bool_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The countyId\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.ContainsByReferencesAsync(System.Collections.Generic.List_string_,System.Nullable_int_,System.Nullable_bool_).inverted'></a>

`inverted` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The inverted\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetEstimatedCoverageFactorAsync(int)'></a>

## OrtoDatasController\.GetEstimatedCoverageFactorAsync\(int\) Method

Retrieves the estimated coverage factor for a specified administrative area 2D identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetEstimatedCoverageFactorAsync(int administrativeAreal2DId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetEstimatedCoverageFactorAsync(int).administrativeAreal2DId'></a>

`administrativeAreal2DId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the administrative area 2D\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') containing the estimated coverage factor or an error status code\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetEstimatedCoverageFactorsAsync(System.Collections.Generic.IEnumerable_int_,System.Nullable_bool_)'></a>

## OrtoDatasController\.GetEstimatedCoverageFactorsAsync\(IEnumerable\<int\>, Nullable\<bool\>\) Method

Retrieves the estimated coverage factors for the specified administrative area identifiers\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetEstimatedCoverageFactorsAsync(System.Collections.Generic.IEnumerable<int> administrativeAreal2DIds, System.Nullable<bool> analyze);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetEstimatedCoverageFactorsAsync(System.Collections.Generic.IEnumerable_int_,System.Nullable_bool_).administrativeAreal2DIds'></a>

`administrativeAreal2DIds` [System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

The collection of administrative area 2D identifiers to be processed\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetEstimatedCoverageFactorsAsync(System.Collections.Generic.IEnumerable_int_,System.Nullable_bool_).analyze'></a>

`analyze` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Boolean](https://learn.microsoft.com/en-us/dotnet/api/system.boolean 'System\.Boolean')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional flag indicating whether to perform an analysis during the retrieval process\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetImageByReferenceAsync(string,short,System.Nullable_int_)'></a>

## OrtoDatasController\.GetImageByReferenceAsync\(string, short, Nullable\<int\>\) Method

Retrieves orthophoto image data based on the provided reference, year, and optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetImageByReferenceAsync(string reference, short year, System.Nullable<int> countyId=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetImageByReferenceAsync(string,short,System.Nullable_int_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string of the orthophoto image\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetImageByReferenceAsync(string,short,System.Nullable_int_).year'></a>

`year` [System\.Int16](https://learn.microsoft.com/en-us/dotnet/api/system.int16 'System\.Int16')

The production or capture year of the orthophoto image\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetImageByReferenceAsync(string,short,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional identifier of the county associated with the orthophoto data\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetItemByReferenceAsync(string,System.Nullable_int_)'></a>

## OrtoDatasController\.GetItemByReferenceAsync\(string, Nullable\<int\>\) Method

Asynchronously retrieves an orthodata item based on the specified reference and optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemByReferenceAsync(string reference, System.Nullable<int> countyId=null);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetItemByReferenceAsync(string,System.Nullable_int_).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string used to locate the orthodata item\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.GetItemByReferenceAsync(string,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional identifier of the county associated with the orthodata item\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.NextBuilding2DReferences(int)'></a>

## OrtoDatasController\.NextBuilding2DReferences\(int\) Method

Retrieves the next batch of building 2D reference objects\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> NextBuilding2DReferences(int count=100);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.NextBuilding2DReferences(int).count'></a>

`count` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The maximum number of building 2D reference objects to retrieve\. Defaults to 100\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.UpdateItemsByCodeAsync(System.Text.Json.Nodes.JsonArray,string)'></a>

## OrtoDatasController\.UpdateItemsByCodeAsync\(JsonArray, string\) Method

Updates items identified by a specific code using the provided JSON array\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemsByCodeAsync(System.Text.Json.Nodes.JsonArray? jsonArray, string code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.UpdateItemsByCodeAsync(System.Text.Json.Nodes.JsonArray,string).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the updated item data\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.UpdateItemsByCodeAsync(System.Text.Json.Nodes.JsonArray,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier or code used to identify the items for update\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.UpdateItemsByCountyIdAsync(System.Text.Json.Nodes.JsonArray,int)'></a>

## OrtoDatasController\.UpdateItemsByCountyIdAsync\(JsonArray, int\) Method

Updates orthodata items associated with a specific county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemsByCountyIdAsync(System.Text.Json.Nodes.JsonArray? jsonArray, int countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.UpdateItemsByCountyIdAsync(System.Text.Json.Nodes.JsonArray,int).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the orthodata items to be updated\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasController.UpdateItemsByCountyIdAsync(System.Text.Json.Nodes.JsonArray,int).countyId'></a>

`countyId` [System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

The unique identifier of the county for which the updates are applied\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasFromDatabasePostTask'></a>

## OrtoDatasFromDatabasePostTask Class

Handles the process of posting orthodata retrieved from the database\.

```csharp
public class OrtoDatasFromDatabasePostTask : DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → [OrtoDatasPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask 'DiGi\.GIS\.WebAPI\.Classes\.OrtoDatasPostTask') → OrtoDatasFromDatabasePostTask
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasFromDatabasePostTask.OrtoDatasFromDatabasePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## OrtoDatasFromDatabasePostTask\(GISWebAPIManager\) Constructor

Handles the process of posting orthodata retrieved from the database\.

```csharp
public OrtoDatasFromDatabasePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasFromDatabasePostTask.OrtoDatasFromDatabasePostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for handling GIS PostgreSQL Web API communications\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask'></a>

## OrtoDatasPostTask Class

Handles the posting of OrtoDatas objects to the PostgreSQL web API\.

```csharp
public class OrtoDatasPostTask : DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask<DiGi.GIS.Classes.OrtoDatas>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.GIS\.Classes\.OrtoDatas](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.ortodatas 'DiGi\.GIS\.Classes\.OrtoDatas')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → OrtoDatasPostTask

Derived  
↳ [OrtoDatasFromDatabasePostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.OrtoDatasFromDatabasePostTask 'DiGi\.GIS\.WebAPI\.Classes\.OrtoDatasFromDatabasePostTask')
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask.OrtoDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## OrtoDatasPostTask\(GISWebAPIManager\) Constructor

Handles the posting of OrtoDatas objects to the PostgreSQL web API\.

```csharp
public OrtoDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask.OrtoDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager instance used to handle PostgreSQL web API operations\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask.Code'></a>

## OrtoDatasPostTask\.Code Property

Gets or sets the code associated with the OrtoDatas post task\.

```csharp
public string? Code { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasTask'></a>

## OrtoDatasTask Class

Handles the background processing of orthophoto data within the GIS PostgreSQL context\.

```csharp
public class OrtoDatasTask : DiGi.Core.Classes.ReportableBackgroundTask<long>, DiGi.GIS.PostgreSQL.Interfaces.IGISPostgreSQLObject, DiGi.Core.Interfaces.IObject
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → OrtoDatasTask

Implements [DiGi\.GIS\.PostgreSQL\.Interfaces\.IGISPostgreSQLObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.interfaces.igispostgresqlobject 'DiGi\.GIS\.PostgreSQL\.Interfaces\.IGISPostgreSQLObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasTask.OrtoDatasTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager)'></a>

## OrtoDatasTask\(GISWebAPIManager, GISPostgreSQLConverterManager\) Constructor

Initializes a new instance of the OrtoDatasTask class\.

```csharp
public OrtoDatasTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager? GISWebAPIManager, DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasTask.OrtoDatasTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The manager responsible for handling GIS PostgreSQL Web API operations\.

<a name='DiGi.GIS.WebAPI.Classes.OrtoDatasTask.OrtoDatasTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager,DiGi.GIS.PostgreSQL.Classes.GISPostgreSQLConverterManager).gISPostgreSQLConverterManager'></a>

`gISPostgreSQLConverterManager` [DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.gispostgresqlconvertermanager 'DiGi\.GIS\.PostgreSQL\.Classes\.GISPostgreSQLConverterManager')

The manager that handles conversion processes for GIS data within a PostgreSQL database context\.

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions'></a>

## SerializableObjectsPostOptions Class

Represents the configuration options for posting serializable objects, extending the base post options functionality\.

```csharp
public class SerializableObjectsPostOptions : DiGi.WebAPI.Classes.PostOptions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.Core\.Classes\.SerializableOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableoptions 'DiGi\.Core\.Classes\.SerializableOptions') → [DiGi\.WebAPI\.Classes\.PostOptions](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.postoptions 'DiGi\.WebAPI\.Classes\.PostOptions') → SerializableObjectsPostOptions
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions.SerializableObjectsPostOptions()'></a>

## SerializableObjectsPostOptions\(\) Constructor

Initializes a new instance of the SerializableObjectsPostOptions class\.

```csharp
public SerializableObjectsPostOptions();
```

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions.SerializableObjectsPostOptions(DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions)'></a>

## SerializableObjectsPostOptions\(SerializableObjectsPostOptions\) Constructor

Initializes a new instance of the SerializableObjectsPostOptions class using values from an existing instance\.

```csharp
public SerializableObjectsPostOptions(DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions? serializableObjectsPostOptions);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions.SerializableObjectsPostOptions(DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions).serializableObjectsPostOptions'></a>

`serializableObjectsPostOptions` [SerializableObjectsPostOptions](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostOptions')

The source options instance to copy values from, or [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null') to use default settings\.

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions.SerializableObjectsPostOptions(System.Text.Json.Nodes.JsonObject)'></a>

## SerializableObjectsPostOptions\(JsonObject\) Constructor

Initializes a new instance of the SerializableObjectsPostOptions class using the specified JSON object\.

```csharp
public SerializableObjectsPostOptions(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions.SerializableObjectsPostOptions(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the options\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions.BatchMemorySize'></a>

## SerializableObjectsPostOptions\.BatchMemorySize Property

Gets or sets the memory size threshold in bytes used for processing batches of serializable objects\.

```csharp
public int BatchMemorySize { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_'></a>

## SerializableObjectsPostTask\<T\> Class

Represents a base class for background tasks that handle the posting of serializable GIS objects to the PostgreSQL database\.

```csharp
public abstract class SerializableObjectsPostTask<T> : DiGi.Core.Classes.ReportableBackgroundTask<long>, DiGi.GIS.WebAPI.Interfaces.IGISWebAPIObject, DiGi.Core.Interfaces.IObject
    where T : DiGi.Core.Interfaces.ISerializableObject
```
#### Type parameters

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_.T'></a>

`T`

The type of serializable object being posted, which must implement [DiGi\.Core\.Interfaces\.ISerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iserializableobject 'DiGi\.Core\.Interfaces\.ISerializableObject')\.

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → SerializableObjectsPostTask\<T\>

Derived  
↳ [AdministrativeAreal2DsPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.AdministrativeAreal2DsPostTask 'DiGi\.GIS\.WebAPI\.Classes\.AdministrativeAreal2DsPostTask')  
↳ [Building2DsPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.Building2DsPostTask 'DiGi\.GIS\.WebAPI\.Classes\.Building2DsPostTask')  
↳ [EPWFilesPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.EPWFilesPostTask 'DiGi\.GIS\.WebAPI\.Classes\.EPWFilesPostTask')  
↳ [OccupancyDatasPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.OccupancyDatasPostTask 'DiGi\.GIS\.WebAPI\.Classes\.OccupancyDatasPostTask')  
↳ [OrtoDatasPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.OrtoDatasPostTask 'DiGi\.GIS\.WebAPI\.Classes\.OrtoDatasPostTask')  
↳ [YearBuiltDatasPostTask](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.YearBuiltDatasPostTask 'DiGi\.GIS\.WebAPI\.Classes\.YearBuiltDatasPostTask')

Implements [DiGi\.GIS\.WebAPI\.Interfaces\.IGISWebAPIObject](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.webapi.interfaces.igiswebapiobject 'DiGi\.GIS\.WebAPI\.Interfaces\.IGISWebAPIObject'), [DiGi\.Core\.Interfaces\.IObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.interfaces.iobject 'DiGi\.Core\.Interfaces\.IObject')
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_.SerializableObjectsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## SerializableObjectsPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the SerializableObjectsPostTask class\.

```csharp
public SerializableObjectsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager gISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_.SerializableObjectsPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).gISWebAPIManager'></a>

`gISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The GIS PostgreSQL Web API manager used to perform database operations\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_.SerializableObjectsPostOptions'></a>

## SerializableObjectsPostTask\<T\>\.SerializableObjectsPostOptions Property

Gets or sets the options used for posting serializable objects\.

```csharp
public DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions SerializableObjectsPostOptions { get; set; }
```

#### Property Value
[SerializableObjectsPostOptions](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostOptions 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostOptions')

<a name='DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_.Values'></a>

## SerializableObjectsPostTask\<T\>\.Values Property

Gets or sets the collection of serializable objects to be posted\.

```csharp
public System.Collections.Generic.IEnumerable<T>? Values { get; set; }
```

#### Property Value
[System\.Collections\.Generic\.IEnumerable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')[T](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_.T 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>\.T')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1 'System\.Collections\.Generic\.IEnumerable\`1')

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter'></a>

## SinglevalueAggregateRequestParameter Class

Parameter class containing options for single\-value database aggregation queries\.

```csharp
public class SinglevalueAggregateRequestParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → SinglevalueAggregateRequestParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.SinglevalueAggregateRequestParameter()'></a>

## SinglevalueAggregateRequestParameter\(\) Constructor

Initializes a new instance of the [SinglevalueAggregateRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.SinglevalueAggregateRequestParameter') class\.

```csharp
public SinglevalueAggregateRequestParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.SinglevalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject)'></a>

## SinglevalueAggregateRequestParameter\(JsonObject\) Constructor

Initializes a new instance of the [SinglevalueAggregateRequestParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter 'DiGi\.GIS\.WebAPI\.Classes\.SinglevalueAggregateRequestParameter') class using a [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public SinglevalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.SinglevalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The JSON object containing data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.ColumnUniqueId'></a>

## SinglevalueAggregateRequestParameter\.ColumnUniqueId Property

Gets or sets the column unique identifier to calculate statistics for\.

```csharp
public string ColumnUniqueId { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

### Example
"col\_unique\_id\_123"

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.CountyId'></a>

## SinglevalueAggregateRequestParameter\.CountyId Property

Gets or sets the target partition identifier \(County ID\)\.

```csharp
public int CountyId { get; set; }
```

#### Property Value
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')

### Example
10365

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.FilterGroup'></a>

## SinglevalueAggregateRequestParameter\.FilterGroup Property

Gets or sets the optional dynamic hierarchical filters to apply prior to aggregation\.

```csharp
public DiGi.PostgreSQL.Table.Classes.FilterGroup? FilterGroup { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.filtergroup 'DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup')

<a name='DiGi.GIS.WebAPI.Classes.SinglevalueAggregateRequestParameter.SinglevalueAggregateFunction'></a>

## SinglevalueAggregateRequestParameter\.SinglevalueAggregateFunction Property

Gets or sets the single\-value aggregation function to perform\.

```csharp
public DiGi.PostgreSQL.Table.Enums.SinglevalueAggregateFunction SinglevalueAggregateFunction { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Enums\.SinglevalueAggregateFunction](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.enums.singlevalueaggregatefunction 'DiGi\.PostgreSQL\.Table\.Enums\.SinglevalueAggregateFunction')

### Example
Sum

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter'></a>

## UniqueValuesByColumnUniqueIdParameter Class

Represents a parameter containing column unique id for querying unique values\.

```csharp
public class UniqueValuesByColumnUniqueIdParameter : DiGi.WebAPI.Classes.Parameter
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.Object](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.object 'DiGi\.Core\.Classes\.Object') → [DiGi\.Core\.Classes\.SerializableObject](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.serializableobject 'DiGi\.Core\.Classes\.SerializableObject') → [DiGi\.WebAPI\.Classes\.Parameter](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.parameter 'DiGi\.WebAPI\.Classes\.Parameter') → UniqueValuesByColumnUniqueIdParameter
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.UniqueValuesByColumnUniqueIdParameter()'></a>

## UniqueValuesByColumnUniqueIdParameter\(\) Constructor

Initializes a new instance of the [UniqueValuesByColumnUniqueIdParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter 'DiGi\.GIS\.WebAPI\.Classes\.UniqueValuesByColumnUniqueIdParameter') class\.

```csharp
public UniqueValuesByColumnUniqueIdParameter();
```

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.UniqueValuesByColumnUniqueIdParameter(string,System.Nullable_int_)'></a>

## UniqueValuesByColumnUniqueIdParameter\(string, Nullable\<int\>\) Constructor

Initializes a new instance of the [UniqueValuesByColumnUniqueIdParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter 'DiGi\.GIS\.WebAPI\.Classes\.UniqueValuesByColumnUniqueIdParameter') class with the specified column unique id and county id\.

```csharp
public UniqueValuesByColumnUniqueIdParameter(string columnUniqueId, System.Nullable<int> countyId);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.UniqueValuesByColumnUniqueIdParameter(string,System.Nullable_int_).columnUniqueId'></a>

`columnUniqueId` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique identifier of the column\.

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.UniqueValuesByColumnUniqueIdParameter(string,System.Nullable_int_).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

The optional unique identifier of the county\.

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.UniqueValuesByColumnUniqueIdParameter(System.Text.Json.Nodes.JsonObject)'></a>

## UniqueValuesByColumnUniqueIdParameter\(JsonObject\) Constructor

Initializes a new instance of the [UniqueValuesByColumnUniqueIdParameter](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter 'DiGi\.GIS\.WebAPI\.Classes\.UniqueValuesByColumnUniqueIdParameter') class using an [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') object\.

```csharp
public UniqueValuesByColumnUniqueIdParameter(System.Text.Json.Nodes.JsonObject jsonObject);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.UniqueValuesByColumnUniqueIdParameter(System.Text.Json.Nodes.JsonObject).jsonObject'></a>

`jsonObject` [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject')

The [System\.Text\.Json\.Nodes\.JsonObject](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonobject 'System\.Text\.Json\.Nodes\.JsonObject') containing the data used to initialize the parameter\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.ColumnUniqueId'></a>

## UniqueValuesByColumnUniqueIdParameter\.ColumnUniqueId Property

Gets or sets the unique identifier of the column \(Column\.UniqueId\)\.

```csharp
public string ColumnUniqueId { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.CountyId'></a>

## UniqueValuesByColumnUniqueIdParameter\.CountyId Property

Gets or sets the county identifier\.

```csharp
public System.Nullable<int> CountyId { get; set; }
```

#### Property Value
[System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

<a name='DiGi.GIS.WebAPI.Classes.UniqueValuesByColumnUniqueIdParameter.FilterGroup'></a>

## UniqueValuesByColumnUniqueIdParameter\.FilterGroup Property

Gets or sets the optional dynamic hierarchical filters to apply prior to retrieving unique values\.

```csharp
public DiGi.PostgreSQL.Table.Classes.FilterGroup? FilterGroup { get; set; }
```

#### Property Value
[DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup](https://learn.microsoft.com/en-us/dotnet/api/digi.postgresql.table.classes.filtergroup 'DiGi\.PostgreSQL\.Table\.Classes\.FilterGroup')

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController'></a>

## YearBuiltDataController Class

Provides API endpoints for managing and updating year built data stored in a PostgreSQL database\.

```csharp
public class YearBuiltDataController : DiGi.WebAPI.Classes.WebAPIController
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [Microsoft\.AspNetCore\.Mvc\.ControllerBase](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.controllerbase 'Microsoft\.AspNetCore\.Mvc\.ControllerBase') → [DiGi\.WebAPI\.Classes\.WebAPIController](https://learn.microsoft.com/en-us/dotnet/api/digi.webapi.classes.webapicontroller 'DiGi\.WebAPI\.Classes\.WebAPIController') → YearBuiltDataController
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.YearBuiltDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.YearBuiltDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter)'></a>

## YearBuiltDataController\(GISWebAPIConfigurationFileWatcher, YearBuiltDataPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter\) Constructor

Initializes a new instance of the YearBuiltDataController class\.

```csharp
public YearBuiltDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, DiGi.GIS.PostgreSQL.Classes.YearBuiltDataPostgreSQLConverter yearBuiltDataPostgreSQLConverter, DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.YearBuiltDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.YearBuiltDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).GISWebAPIConfigurationFileWatcher'></a>

`GISWebAPIConfigurationFileWatcher` [GISWebAPIConfigurationFileWatcher](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIConfigurationFileWatcher')

The configuration file watcher used to monitor changes to the PostgreSQL Web API configuration\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.YearBuiltDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.YearBuiltDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).yearBuiltDataPostgreSQLConverter'></a>

`yearBuiltDataPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.YearBuiltDataPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.yearbuiltdatapostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.YearBuiltDataPostgreSQLConverter')

The converter for YearBuiltData objects when interacting with a PostgreSQL database\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.YearBuiltDataController(DiGi.GIS.WebAPI.Classes.GISWebAPIConfigurationFileWatcher,DiGi.GIS.PostgreSQL.Classes.YearBuiltDataPostgreSQLConverter,DiGi.GIS.PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter).administrativeAreal2DPostgreSQLConverter'></a>

`administrativeAreal2DPostgreSQLConverter` [DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.postgresql.classes.administrativeareal2dpostgresqlconverter 'DiGi\.GIS\.PostgreSQL\.Classes\.AdministrativeAreal2DPostgreSQLConverter')

The converter for administrative areal 2D data when interacting with a PostgreSQL database\.
### Methods

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.GetItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken)'></a>

## YearBuiltDataController\.GetItemsByReferenceAsync\(string, Nullable\<int\>, CancellationToken\) Method

Asynchronously retrieves items based on a provided reference and an optional county identifier\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> GetItemsByReferenceAsync(string reference, System.Nullable<int> countyId, System.Threading.CancellationToken cancellationToken=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.GetItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken).reference'></a>

`reference` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The unique reference string used to identify the year built data items\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.GetItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken).countyId'></a>

`countyId` [System\.Nullable&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1 'System\.Nullable\`1')

An optional integer representing the county ID to filter the results\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.GetItemsByReferenceAsync(string,System.Nullable_int_,System.Threading.CancellationToken).cancellationToken'></a>

`cancellationToken` [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken')

The [System\.Threading\.CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken 'System\.Threading\.CancellationToken') to observe for cancellation requests\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
A task that represents the asynchronous operation\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string)'></a>

## YearBuiltDataController\.UpdateItemsAsync\(JsonArray, string\) Method

Updates multiple year built data items based on the provided JSON array and identification code\.

```csharp
public System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.IActionResult> UpdateItemsAsync(System.Text.Json.Nodes.JsonArray? jsonArray, string code);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string).jsonArray'></a>

`jsonArray` [System\.Text\.Json\.Nodes\.JsonArray](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.nodes.jsonarray 'System\.Text\.Json\.Nodes\.JsonArray')

The JSON array containing the data items to be updated\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDataController.UpdateItemsAsync(System.Text.Json.Nodes.JsonArray,string).code'></a>

`code` [System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')

The identification code required for the update operation\.

#### Returns
[System\.Threading\.Tasks\.Task&lt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')[Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1 'System\.Threading\.Tasks\.Task\`1')  
An [Microsoft\.AspNetCore\.Mvc\.IActionResult](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.iactionresult 'Microsoft\.AspNetCore\.Mvc\.IActionResult') representing the result of the update operation\.

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDatasPostTask'></a>

## YearBuiltDatasPostTask Class

Provides functionality to handle the asynchronous posting of [DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData') collections to the PostgreSQL database\.

```csharp
public class YearBuiltDatasPostTask : DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask<DiGi.GIS.Classes.YearBuiltData>
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → [DiGi\.Core\.Classes\.BackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.backgroundtask 'DiGi\.Core\.Classes\.BackgroundTask') → [DiGi\.Core\.Classes\.CancelableBackgroundTask](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.cancelablebackgroundtask 'DiGi\.Core\.Classes\.CancelableBackgroundTask') → [DiGi\.Core\.Classes\.ReportableBackgroundTask&lt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1')[System\.Int64](https://learn.microsoft.com/en-us/dotnet/api/system.int64 'System\.Int64')[&gt;](https://learn.microsoft.com/en-us/dotnet/api/digi.core.classes.reportablebackgroundtask-1 'DiGi\.Core\.Classes\.ReportableBackgroundTask\`1') → [DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask&lt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>')[DiGi\.GIS\.Classes\.YearBuiltData](https://learn.microsoft.com/en-us/dotnet/api/digi.gis.classes.yearbuiltdata 'DiGi\.GIS\.Classes\.YearBuiltData')[&gt;](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.SerializableObjectsPostTask_T_ 'DiGi\.GIS\.WebAPI\.Classes\.SerializableObjectsPostTask\<T\>') → YearBuiltDatasPostTask
### Constructors

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDatasPostTask.YearBuiltDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager)'></a>

## YearBuiltDatasPostTask\(GISWebAPIManager\) Constructor

Initializes a new instance of the YearBuiltDatasPostTask class\.

```csharp
public YearBuiltDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager GISWebAPIManager);
```
#### Parameters

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDatasPostTask.YearBuiltDatasPostTask(DiGi.GIS.WebAPI.Classes.GISWebAPIManager).GISWebAPIManager'></a>

`GISWebAPIManager` [GISWebAPIManager](DiGi.GIS.WebAPI.Classes.md#DiGi.GIS.WebAPI.Classes.GISWebAPIManager 'DiGi\.GIS\.WebAPI\.Classes\.GISWebAPIManager')

The GIS PostgreSQL Web API manager used to handle data persistence\.
### Properties

<a name='DiGi.GIS.WebAPI.Classes.YearBuiltDatasPostTask.Code'></a>

## YearBuiltDatasPostTask\.Code Property

Gets or sets the code associated with the year built data post task\.

```csharp
public string? Code { get; set; }
```

#### Property Value
[System\.String](https://learn.microsoft.com/en-us/dotnet/api/system.string 'System\.String')