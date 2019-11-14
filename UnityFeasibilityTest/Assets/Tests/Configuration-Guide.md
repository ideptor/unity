## Unity TDD 할때 폴더 구조가 정해져 있어 수동으로 Assembly Definition Reference 작업을 해주어야 함.
https://stackoverflow.com/questions/50223866/how-to-set-up-unit-tests-in-unity-and-fix-missing-assembly-reference-error

### 문제가 되는 부분

Unity 2018.4.10f 기준으로 Test를 진행하려면 아래와 같은 모습으로 만들어짐.
(`Windows -> Test Runner -> EditMode -> "Create Test Assembly Folder"
```
|--Scripts
|   +-- Heart.cs         (기능이 구현된 코드)
|
|--Tests
|   +-- HeartTests.cs    (테스트 코드)
|   +-- Tests.asmdef
```
Visual Studio 에서는 아래와 같이 두개의 프로젝트로 나누어짐
- Assembly-CSharp (Heart.cs)
- Tests (HeartTests.cs)

이 경우 `HeartTests` 에서 `Heart`를 참조하지 못해 아래와 같은 에러가 발생함
> Assets\Tests\HeartTest.cs(12,17): error CS0246: The type or namespace name 'Heart' could not be found (are you missing a using directive or an assembly reference?)

### 해결 방법
1. Unity Editor 에서 `Scripts`폴더에 `MyScriptAssembly.asmdef`를 만든다. (메뉴에서 `Assets -> Create -> Assembly Definition`)
   ```
   {
      "name": "MyScriptAssembly"
   }
   ```
1. `Tests.asmdef`에 위에서 만든 Script Assembly를 입력한다. (수동으로 하거나 Unity Editor의 Inspector탭에서 가능)

   ```json
   {
       "name": "Tests",
       "references": [
           "MyScriptAssembly"
       ],
       "optionalUnityReferences": [
           "TestAssemblies"
       ],
       "includePlatforms": [
           "Editor"
       ],
       "excludePlatforms": [],
       "allowUnsafeCode": false
   }
   ```


