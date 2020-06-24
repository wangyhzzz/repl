#include <iostream>
#include <basetyps.h>
#include "repl.h"

using namespace std;
EXTERN_C int __stdcall Hello(){
    cout << "hello unity" << endl;
    return 0;
}

int main() {
    cout << "sdf" << endl;
}