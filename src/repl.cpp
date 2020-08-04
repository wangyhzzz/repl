#include <iostream>
#include <windows.h>
#include "repl.h"
#include <readline/readline.h>
#include <readline/history.h>
#include <thread>
#include <list>


using namespace std;
typedef list<string> CMDLIST;
CMDLIST cmdlist;

int main() {
    init();
    while (1) {
        getline();
        Sleep(1);
    }
    return 0;
}

int init() {
    static bool inited = false;
    if (inited) {
        return 0;
    }
    inited = true;
    auto ret = AllocConsole();
    system("chcp 65001");
    freopen("CONIN$", "r", stdin);
    freopen("CONOUT$", "w", stdout);
//    freopen("CONOUT$", "w", stderr);
    std::thread t(repl);
    t.detach();
    return ret;
}


void repl() {
    char *temp;
    using_history();
    read_history(nullptr);
    write_history(nullptr);
    while ((temp = readline(nullptr))) {

        /* Check for `command' that we handle. */
        if (strcmp(temp, "quit") == 0)exit(0);
        if (strcmp(temp, "exit") == 0)exit(0);
        if (strcmp(temp, "list") == 0) {
            HIST_ENTRY **list;
            register int i;

            list = history_list();
            if (list) {
                for (i = 0; list[i]; i++)
                    fprintf(stdout, "%d: %s\r\n", i, list[i]->line);
            }
        } else if (*temp) {
            cmdlist.push_back(temp);
            add_history(temp);
            append_history(1, nullptr);
        }
        free(temp);
    }
    exit(1);
}

BSTR getline() {
    if (cmdlist.empty())
        return nullptr;
    auto ret = cmdlist.front();
    cmdlist.pop_front();
    auto wstr = wstring(ret.begin(), ret.end());
    BSTR s = ::SysAllocString(wstr.c_str());
    return s;
}
