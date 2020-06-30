cmake_minimum_required(VERSION 3.6)
project(repl)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11 -DRL_LIBRARY_VERSION=8.0 ")
link_libraries(readline history termcap)

include_directories("${PROJECT_SOURCE_DIR}/")

link_directories("${PROJECT_SOURCE_DIR}/prebuilt/x64")

include(CheckIncludeFile)
set(SOURCE_FILES src/repl.cpp)
add_executable(repl ${SOURCE_FILES})
add_library(UnityRepl SHARED ${SOURCE_FILES})
add_custom_command(TARGET UnityRepl
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_BINARY_DIR}/libUnityRepl.dll 'E:/XMASTER/xMasterClient5.6/Assets/Plugins/x86_64'
        )
#set_target_properties(
#        UnityRepl
#        PROPERTIES
#        CMAKE_RUNTIME_OUTPUT_DIRECTORY 'E:/XMASTER/xMasterClient5.6/Assets/Plugins/a/'
#)
#
