# **Check AdMob SDK Update for Unity**

A Unity Editor plugin that checks whether your Google Mobile Ads (AdMob) Unity SDK is up to date by comparing the installed version with the latest release available on GitHub.

<div align="center">
  <img src="https://github.com/yashlan/unity-admob-sdk-checker/blob/main/ss/ss_confirm_window.png" width="450" />
</div>

---

## **Features**
- Automatically detects the local AdMob SDK version based on manifest files.
- Fetches the latest version of the AdMob SDK from the GitHub repository.
- Compares the local version with the latest release:
  - Displays a warning if the version is outdated.
  - Provides an option to open the download page for the latest version.
  - Notifies if the local version is ahead of the release or already up to date.
- Integrates seamlessly into the Unity Editor with a customizable menu item.

---

# Installation

Install the package directly from GitHub using Unity Package Manager.

## Requirements

- Unity **2022.3 LTS** or newer
- **Google Mobile Ads Unity SDK** already installed

## Install via Git URL

1. Open **Unity**.
2. Go to **Window → Package Management → Package Manager**.
3. Click the **+** button in the top-left corner.
4. Select **Install package from Git URL...**.
5. Paste the following URL:

```text
https://github.com/yashlan/AdMob-SDK-Update-Checker.git?path=/Assets/release
```

6. Click **Install**.

<div align="left">
<img src="https://github.com/yashlan/unity-admob-sdk-checker/blob/main/ss/ss_install_package.png" width="700" />
</div>

## Open the Tool

After installation, open:

```text
Tools → Check Update AdMob SDK
```

The tool will automatically detect the installed Google Mobile Ads Unity SDK version and notify you if a newer version is available.

<img src="https://github.com/yashlan/unity-admob-sdk-checker/blob/main/ss/ss_console.png" width="700" />

---

## **Customizing the Menu**
<img src="https://github.com/yashlan/unity-admob-sdk-checker/blob/main/ss/ss_menu_item.png" width="350" />

The menu name can be changed by modifying the `MenuItem` attribute in this section's script.  
Here's the code:  
```csharp
[MenuItem("My Menu/Check Update Admob SDK", validate = false, priority = 1)] // path: Assets/release/Editor/CustomMenuAdmob.cs

