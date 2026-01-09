# MAUI SkeletonLoader

[![NuGet version (RedEye.Maui.SkeletonLoader)](https://img.shields.io/nuget/v/RedEye.Maui.SkeletonLoader.svg?style=flat-square)](https://www.nuget.org/packages/RedEye.Maui.SkeletonLoader/)

A lightweight, customizable **Skeleton Loader** for **.NET MAUI** that provides animated placeholder UI elements while content is loading.

This library supports both **rectangular** and **circular (ellipse)** skeleton loaders with smooth gradient wave animations.

---

## ✨ Features

* 🚀 Smooth shimmer / wave animation
* 🟦 Rectangular skeleton loader (`BSkeletonLoader`)
* ⚪ Circular skeleton loader (`ESkeletonLoader`)
* ⚙️ Fully customizable speed, delay, and size
* 🧩 Easy XAML usage
* ♻️ Automatic start / stop based on view lifecycle

---

## 📦 Namespace

```xml
xmlns:sl="clr-namespace:SkeletonLoader;assembly=SkeletonLoader"
```

---

## 🔧 Bindable Properties

### Common Properties (`BSkeletonLoader`, `ESkeletonLoader`)

| Property      | Type     | Default | Description                                         |
| ------------- | -------- | ------- | --------------------------------------------------- |
| `Speed`       | `double` | `1.0`   | Controls the animation speed (higher = faster wave) |
| `DelaySecond` | `double` | `1.0`   | Delay before the animation restarts (in seconds)    |

---

### `ESkeletonLoader` Specific Properties

| Property | Type  | Default | Description                                             |
| -------- | ----- | ------- | ------------------------------------------------------- |
| `Size`   | `int` | `10`    | Controls both width and height of the circular skeleton |

---

## 🟦 BSkeletonLoader (Border-based)

A rectangular skeleton loader built on top of `Border`. Ideal for text lines, cards, and content blocks.

![BSkeletonLoader](https://raw.githubusercontent.com/RedEye-Developers/MauiSkeletonLoader/refs/heads/master/MauiSkeletonLoader/Docs/Images/BSkeleton.gif)

### Example

```xml
<sl:BSkeletonLoader WidthRequest="400"
                    HeightRequest="240"
                    StrokeShape="RoundRectangle 15" />
```

---

## ⚪ ESkeletonLoader (Ellipse-based)

A circular skeleton loader implemented as a `ContentView` wrapping an `Ellipse`. Perfect for avatars or profile images.

![ESkeletonLoader](https://raw.githubusercontent.com/RedEye-Developers/MauiSkeletonLoader/refs/heads/master/MauiSkeletonLoader/Docs/Images/ESkeleton.gif)

### Example

```xml
<sl:ESkeletonLoader Size="50" />
```

---

## 🧩 Multiple Skeleton Loaders Example

You can easily combine multiple skeleton loaders to simulate complex layouts.

![MultipleSkeletonLoader](https://raw.githubusercontent.com/RedEye-Developers/MauiSkeletonLoader/refs/heads/master/MauiSkeletonLoader/Docs/Images/SkeleonLoaders.gif)

```xml
<VerticalStackLayout
    HorizontalOptions="Center"
    VerticalOptions="Center"
    Spacing="15">

    <HorizontalStackLayout Spacing="10">

        <sl:ESkeletonLoader Size="50" />

        <VerticalStackLayout Spacing="10" Margin="0,15,0,0">
            <sl:BSkeletonLoader
                WidthRequest="300"
                HeightRequest="8"
                StrokeShape="RoundRectangle 50" />

            <sl:BSkeletonLoader
                WidthRequest="150"
                HeightRequest="8"
                StrokeShape="RoundRectangle 50"
                HorizontalOptions="Start" />
        </VerticalStackLayout>
    </HorizontalStackLayout>

    <sl:BSkeletonLoader
        WidthRequest="400"
        HeightRequest="240"
        StrokeShape="RoundRectangle 15" />

    <VerticalStackLayout Spacing="10" Margin="0,15,0,0">
        <sl:BSkeletonLoader
            WidthRequest="300"
            HeightRequest="8"
            StrokeShape="RoundRectangle 50"
            HorizontalOptions="Start" />

        <sl:BSkeletonLoader
            WidthRequest="200"
            HeightRequest="8"
            StrokeShape="RoundRectangle 50"
            HorizontalOptions="Start" />
    </VerticalStackLayout>
</VerticalStackLayout>
```

---

## ⚙️ Lifecycle & Animation Handling

* Animation starts automatically when the control is **loaded**
* Animation stops and cleans up when the control is **unloaded**
* Uses `CancellationTokenSource` for safe async animation control
* Prevents animation leaks when views are removed

---

## 🛠 Implementation Notes

* `BSkeletonLoader` inherits from `Border`
* `ESkeletonLoader` wraps an `Ellipse` inside a `ContentView` (Shapes cannot be inherited directly)
* Gradient animation is handled via `Animation.Commit`
* Self-referencing bindings are used for clean XAML-to-code interaction

---

## 🚫 Error Handling

If an unexpected lifecycle issue occurs (e.g., animation started before initialization), a diagnostic message is emitted:

```text
SkeletonLoader Error : CancellationTokenSource was Null, Report to Developer!
```

(Recommended to replace this with `ILogger` for production NuGet packages.)

---

## 📄 License

MIT License

Copyright (c) 2026 RedEye-Developers

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.


---

## 🙌 Contributions

Contributions, issues, and feature requests are welcome!
Feel free to open a PR or submit an issue.

---

Happy coding 🚀

RedEye-Developers
