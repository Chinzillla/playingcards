Changes for Mono compatibility:

| Modern C# | Old C# equivalent |
|---|---|
| `switch expression` (`x switch { ... }`) | `switch statement` (`switch(x) { case: ... }`) |
| `primary constructor` (`class Foo(int x)`) | Regular constructor with `this.x = x` |
| `=> property` (`public override int X => y`) | `get { return y; }` |
| `Enum.Parse<T>(...)` | `(T)Enum.Parse(typeof(T), ...)` |
| `$"string {x}"` | `"string " + x` (safer on old Mono, though interpolation may work) |

Algomonster C# Compiler is oudated

- [Algomonster outdated solution](Solution-Algomonster.md)
- [Ideal Solution](Solution-Ideal.md)