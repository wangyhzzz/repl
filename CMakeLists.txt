cmake_minimum_required(VERSION 3.6)
project(repl)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11 ")

include_directories("${PROJECT_SOURCE_DIR}/libs/")

link_directories("${PROJECT_SOURCE_DIR}/libs/glfw/lib-mingw/")
link_directories("${PROJECT_SOURCE_DIR}/libs/glad/")

include(CheckIncludeFile)
set(SOURCE_FILES
        src/repl.cpp
        )
add_executable(repl ${SOURCE_FILES})
add_library(UnityRepl SHARED ${SOURCE_FILES})
add_custom_command(TARGET UnityRepl
        POST_BUILD
        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_BINARY_DIR}/libUnityRepl.dll 'E:/XMASTER/xMasterClient5.6/Assets/Plugins'
        )
#set_target_properties(
#        UnityRepl
#        PROPERTIES
#        CMAKE_RUNTIME_OUTPUT_DIRECTORY 'E:/XMASTER/xMasterClient5.6/Assets/Plugins/a/'
#)
#
