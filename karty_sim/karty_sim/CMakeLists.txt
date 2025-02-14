cmake_minimum_required(VERSION 3.24)
project(karty_sim)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_EXE_LINKER_FLAGS "-static -static-libgcc -static-libstdc++")

add_executable(karty_sim main.cpp)
target_link_libraries(karty_sim WinSCard)
