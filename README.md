# KemonoFriendsCMC.Mods.KabanMode

けもフレCMC の かばんちゃん操作用パッチ

## 概要

* サーバルちゃんをかばんちゃんに置き換えます

## かばんちゃん操作方法

* 攻撃ボタン：紙飛行機投げ
  * これ以外ないので、攻撃はできません。

## 動作確認バージョン

* KemonoFriendsCMC_v1.9.0

## 注意点

* 下記の行為はご遠慮ください
1. 著作者（ゲーム本体及びMOD開発者）を騙る行為
2. `けものフレンズプロジェクト 二次創作ガイドライン`（ https://kemono-friends.jp/guideline/ ）に違反する行為

## ビルド手順(開発者向け)

### 以下のファイルをdllフォルダに追加する

* `(BepInExルート)\core` から取得
  * 0Harmony.dll
  * BepInEx.dll
* `(KemonoFriendsCMCルート)\KemonoFriendsCMC_Data\Managed` から取得
  * Assembly-CSharp.dll
  * NavMeshComponents.dll
  * netstandard.dll
  * System.Diagnostics.StackTrace.dll
  * System.dll
  * System.Globalization.Extensions.dll
  * System.IO.Compression.dll
  * System.IO.Compression.FileSystem.dll
  * System.Net.Http.dll
  * System.Runtime.Serialization.Xml.dll
  * System.Xml.XPath.XDocument.dll
  * UnityEngine.AIModule.dll
  * UnityEngine.ClothModule.dll
  * UnityEngine.CoreModule.dll
  * UnityEngine.dll
  * UnityEngine.PhysicsModule.dll

### VisualStudio2019でReleaseビルド

* .NETFramework4が必要
* `KemonoFriendsCMC.Mods.KabanMode\bin\Release\KemonoFriendsCMC.Mods.KabanMode.dll`にプラグインのDLLが出力される