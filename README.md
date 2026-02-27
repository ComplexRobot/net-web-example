# Godot Engine 4.x C# .NET - Web Export

Simple project which enables experimental web export support for C# projects on Windows.

Visit the [Releases](https://github.com/ComplexRobot/net-web-example/releases) for a pre-built binary for windows.

More information is in the release notes.

### Important Information

> [!WARNING]
> Games exported for the web lack support for some features.
>
> Does not support GDExtensions due to the dotnet runtime being built without position-independent code.
>
> From the raulsntos PR:
> * Globalization doesn't work, so for now we're always enabling [invariant mode](https://learn.microsoft.com/en-us/dotnet/core/runtime-config/globalization#invariant-mode).
> * The Mono runtime uses stubs for their exported JavaScript functions, these need to be replaced with the real implementation in their `dotnet.runtime.js` module but we don't have an easy way to do that yet, which means some BCL APIs will not work (i.e.: crypto APIs)

xr0gu3 notes this about uploading to itch.io:
> (don't forget to enable **SharedArrayBuffer support** on itch project dashboard).


### WASM Tools Installation

Exporting for the web requires the .NET workload `wasm-tools` to be installed.

The included `install.bat` will attempt to install `wasm-tools` for your highest installed .NET SDK as well as .NET 9.0.

If you are getting export errors, use the command line `dotnet workload install wasm-tools` to install the workload.

Optionally, you can use a `global.json` (sample file included) to control the .NET SDK version used directly.


### Credit

- [raulsntos](https://github.com/godotengine/godot/pull/106125): For their pull request implementing built-in editor support.
- [xr0gu3](https://github.com/xr0gu3/net-web-example): For providing a docker image and example repo.


### Development Information

In addition to their changes, I've added a change to how export templates are generated based upon the fix in xr0gu3's docker build.

This changes the `js` file in the template directly so that you can export directly from the editor with no post-export changes needed.

Custom build of godot here: [ComplexRobot/godot/dotnet/mono-static-linking](https://github.com/ComplexRobot/godot/tree/dotnet/mono-static-linking)

It's based upon the latest stable version of godot with the PR by raulsntos merged in. (Plus a small change added by xr0gu3.)