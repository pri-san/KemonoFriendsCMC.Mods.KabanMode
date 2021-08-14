# KemonoFriendsCMC.Mods.KabanMode

けものフレンズ Cellien May Cry（以下「ゲーム本体」とする）の かばんちゃん操作用パッチ（以下「本パッチ」とする）

## ゲーム本体の情報
* 製作者様
  * 坂本龍様
    * 連絡先はゲーム本体付属の説明書を参照してください
* ダウンロードURL
  * ふりーむ！：https://www.freem.ne.jp/win/game/25092
  * フリーゲーム夢現：https://freegame-mugen.jp/action/game_9372.html

## 本パッチの概要

* 操作キャラであるサーバルちゃんをかばんちゃんに置き換えます
## かばんちゃん操作方法

* 攻撃ボタン：紙飛行機投げ
  * これ以外ないので、攻撃はできません

## 動作確認バージョン

* KemonoFriendsCMC_v1.9.0

## 注意点

* 本パッチ実行ファイル、及びソースコードは`MITライセンス`です
  * ライセンス本文は`LICENSE`ファイルを参照してください
  * ゲーム本体のライセンスに関してはゲーム本体付属の説明書を参照してください
* 下記の行為はご遠慮ください
1. 著作者（ゲーム本体及び本パッチ開発者）を騙る行為
2. `けものフレンズプロジェクト 二次創作ガイドライン`（ https://kemono-friends.jp/guideline/ ）に違反する行為
3. ゲーム本体の定める規約に違反する行為

## ビルド手順(開発者向け)

### 以下のファイルをdllフォルダに追加

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

### VisualStudioでReleaseビルド

* .NETFramework4が必要です
  * 別途インストールするのではなく、VisualStudioのインストーラを使用するとスムーズにインストールできます
* `KemonoFriendsCMC.Mods.KabanMode\bin\Release\KemonoFriendsCMC.Mods.KabanMode.dll`にプラグインのDLLが出力されます