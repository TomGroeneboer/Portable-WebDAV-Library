v0.8.1.0
- New Timeout property for WebDavSession (default timeout value is 100 seconds).

v0.8.0.0
- When using WebDavClient.DownloadFileWithProgressAsync, the passed Stream does not get disposed automatically. Disposing of this Stream is up to the client calling this method.
- Strongly typed versions of Lock-Token formats as defined in WebDAV specification.
- When using the Portable WebDAV Library on Xamarin, there was a problem when relative URLs (strings) where used (e.g. webDavSession.ListAsync(@"/folder")).
- When using WebDavSession, a base URL (string) can now be specified.
- The 'Translate' header is always set to 'f' for IIS WebDAV serving unmapped file types (see https://msdn.microsoft.com/en-us/library/cc250063.aspx).
- Bugfix: When using WebDavSession with BaseUri and calling methods passing only the relative Uri/URL to a file, these operations always failed.
- Bugfix: When using WebDavSession.UploadFileWithProgressAsync with a URL, there was a stack overflow exception because the method called itself instead of the correct overload.

v0.7.0.0
- The library now targets .NETStandard 1.1 (.NET Core) and can be used on any platform supporting .NETStandard 1.1.
- Due to .NETStandard support, the library is not separated into two parts (UWP/NetFx) anymore. One library for all the target platforms.
- **Breaking change**: The whole library is now based on System.Net.Http.HttpClient. Therefore, there are some changes in the API (e.g. method signatures).
- Upload/download with progress is generally supported, even on projects targeting .NET Framework (formerly the NetFx part of the library).
- The xml:lang attribute is now supported for prop elements.

v0.6.3.0
- **Breaking change**: The owner element now allows any content. If a URL or e mail address should be provided (as simple string), use the property OwnerHref. This is the same behavior as in previous versions of the library. When child elements, mixed content, text content or attributes should be provided for the owner, use the new property OwnerRaw.
- Due to these changes, the owner is not a separate object (WebDavArtifacts) anymore, but represented by the properties OwnerHref and OwnerRaw in the classes ActiveLock and LockInfo.
- WebDavClient: All method overloads accepting a URL as string now construct the Uri with UriKind.RelativeOrAbsolute, so relative URLs can be specified.
-  Changed formatting of Lock-Token header as defined in RFC 4918.

v0.6.2.0
- Added missing property 'SupportedLock' as defined in [RFC 4918](https://tools.ietf.org/html/rfc4918#section-6.7).
- The class LockToken now exposes the internal LockToken value for serialization purposes.
- NetFx: The response headers are now transparently added to the WebDavResponseMessage (i.e. without validation).
- Bugfix: Fix incorrect checks on the existence of the LockToken header in responses.

v0.6.1.0:
- WebDavSession: WebDavSession: new overloads for DownloadFileAsync.
- Bugfix: Fixed problems when URLs were HTML encoded.
- Bugfix: Fixed problems when combining URIs/URLs.
- Workaround when a server returns an invalid ETag header (NetFx only).

v0.6.0.0:
- New overloads for UriHelper.CombineUri supporting a second parameter indicating if duplicated path segments of the second URI should be removed from the resulting URI. E.g. when this parameter is set to true, combining the URIs https://myserver.com/webdav and /webdav/myfile.txt will result in https://myserver.com/webdav/myfile.txt (not https://myserver.com/webdav/webdav/myfile.txt). When this parameter is set to false (or by using the overload omitting this parameter), the URIs simply get combined as they are.
- New overloads for UriHelper.AddTrailingSlash supporting a second parameter indicating if a file is expected in the URI/URL. Before this change, this method did not work with folder names containing a dot ('.').
- New overloads for several methods in UriHelper accepting URLs as string.
- Bugfix: Sometimes WebDavSession.ListAsync also returned the parent (containing) folder (due to wrong combination of URIs).
- Bugfix: Fixed error parsing boolean properties for WebDavSessionListItem.
- WebDavSession.ListAsync: The WebDAV library now uses the original port specified in the request to build the response (if the response comes from a different port internally). 
- New method in UriHelper to remove the port from an URI/URL.
- WebDavSession.ListAsync: When a Prop's DisplayName contains unreadable characters, the last part of the URI is used as WebDavSession ListItem's name instead.

v0.5.3.0:
- Bugfix: Fixed error with combining base URI and relative URI for WebDavSession. 

v0.5.2.0:
- WebDavSession.ListAsync now uses 'allprop' as default.
- New overloads for WebDavSession.ListAsync where a PropFind can be specified (e.g. PropFind.CreatePropFindWithEmptyPropertiesAll()). 
- Updated and improved documentation. 

v0.5.1.0:
- Bugfix: WebDavSession.ListAsync delivered the containing folder if the requested folder path contained spaces. 
- The class PropFind now contains a method to create an empty PropFind (CreatePropFind). With such a PropFind, the server should return all properties known to the server.

v0.5.0.0:
- BREAKING CHANGE: WebDavSession.ListAsync now returns WebDavSessionListItems which contain all WebDAV properties available.
- WebDavSession.ListAsync now returns WebDavSessionListItems with full qualified URIs (not relative URIs anymore).
- Extension of WebDAV object model: Implementation of RFC 4331 (Quota and Size Properties for Distributed Authoring and Versioning (DAV) Collections).
- New methods for uploading/downloading files with progress (UWP only).
- Fixed a few things in the documentation.

v0.4.0.0:
- New method overloads in WebDavClient without requiring a LockToken
- NuGet package available: https://www.nuget.org/packages/PortableWebDavLibrary/

v0.3.0.0:
- Split the Portable WebDAV Library into two parts: DecaTec.WebDav.NetFx.dll (to be used in projects targeting  the .NET Framework, Windows 8 or ASP.NET Core) and DecaTec.WebDav.Uwp.dll (to be used in projects targeting Windows 8.1, Windows Phone 8.1 and apps for the Universal Windows Platform (UWP))
- The split was necessary because there were some issues using the Portable WebDAV Library in Universal Windows Platform (UWP) projects (not being able to ignore invalid SSL certificates and a bug in System.Net.Http.HttpClient making it impossible to access WebDAV resources without receiving an exception). Maybe the Portable WebDAV Library gets merged into one DLL in the future, but as long as there is no consistent API to access web resources in .NET and UWP apps, the library will consist of these two parts

v0.2.0.0:
- Retarget for .NET 4.5 and ASP.NET Core 5.0
- The WebDavSession now uses the class NetworkCredential for user credentials. The class WebDavCredential is not longer supported

v0.1.1.0:
- Optimized URL handling in WebDavSession
- Added a more meaningful WebDavException when ListAsync (WebDavSession) fails due to wrong response status code
- WebDavException is now thrown when parsing a response (multi status or prop) fails

v0.1.0.0:
- Initial release of Portable WebDAV Library
