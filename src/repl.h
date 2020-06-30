#define Unity_API __declspec(dllexport)

void repl();

EXTERN_C BSTR Unity_API getline();
EXTERN_C int Unity_API init();
