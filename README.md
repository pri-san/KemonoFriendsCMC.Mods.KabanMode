# KemonoFriendsCMC.Mods.KabanMode

けものフレンズ Cellien May Cry の かばんちゃん操作用パッチ

## 概要

* 操作キャラであるサーバルちゃんをかばんちゃんに置き換えます

### けものフレンズ Cellien May Cry ゲーム本体情報
* 製作者様
  * 坂本龍様
    * Twitter: @SakamotoRyuu
* ダウンロードURL
  * ふりーむ！：https://www.freem.ne.jp/win/game/25092
  * フリーゲーム夢現：https://freegame-mugen.jp/action/game_9372.html

## かばんちゃん操作方法

* 攻撃ボタン：紙飛行機投げ
  * これ以外ないので、攻撃はできません。

## 動作確認バージョン

* KemonoFriendsCMC_v1.9.0

## 注意点

* 本パッチ実行ファイル、及びソースコードは`MITライセンス`です
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
  * Rewired_Core.dll
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