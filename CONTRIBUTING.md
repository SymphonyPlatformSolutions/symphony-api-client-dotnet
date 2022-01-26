# How to contribute

If you found a bug or issue, please ensure the bug was not already reported by searching in
[GitHub issues](https://github.com/SymphonyPlatformSolutions/symphony-api-client-dotnet/issues).
If you are unable to find an open issue addressing the problem, open a new one.
Be sure to include a title and clear description, the SDK version, and a code sample demonstrating the issue.

If you open a PR to fix any issue, please reference the ticket in the PR title.
A [Symphony SDK team](https://github.com/orgs/SymphonyPlatformSolutions/teams/symphony-sdk/members) member
will have to approve before it is merged and eventually released.

If you want to request an enhancement or feature, please open a Github issue if none has been opened before.
New feature requests on the legacy SDK will not be accepted.

## Module and package structure

Code is structured into two main parts:
* [apiClientDotNet](apiClientDotNet) which contains the source code;
* [apiClientDotNetTest](apiClientDotNetTest) which contains unit tests.

## Testing

Unit tests should be added or updated each time a PR is submitted.

## Coding guidelines

Please stick to the [official C# coding conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions).

## Documentation

Public classes and methods should be properly documented using [XML comments](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc).
