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
#target_compile_definitions(hook_test PUBLIC TEST)

