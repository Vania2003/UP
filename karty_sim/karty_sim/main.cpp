#include <iostream>
#include "winscard.h"
#include <string>
#include <vector>
#include <wininet.h>


using namespace std;

void sendCommand(SCARDHANDLE hCard, BYTE* command, DWORD commandLength) {
    BYTE response[258];
    DWORD responseLength = sizeof(response);
    LONG result = SCardTransmit(hCard, SCARD_PCI_T0, command, commandLength, NULL, response, &responseLength);
    if (result != SCARD_S_SUCCESS) {
        cout << "Blad transmisji" << endl;
        return;
    }

    // Wyświetlanie odpowiedzi w formacie HEX
    cout << "Odpowiedz HEX: ";
    for (DWORD i = 0; i < responseLength; i++) {
        printf("%02X ", response[i]);
    }
    cout << endl;

    // Wyświetlanie odpowiedzi znakowo
    cout << "Odpowiedź znakowa: ";
    for (DWORD i = 0; i < responseLength; i++) {
        if (isprint(response[i])) {
            cout << (char)response[i];
        } else {
            cout << ".";
        }
    }
    cout << endl;
}

int main() {
    SCARDCONTEXT hContext;
    SCARDHANDLE hCard;
    DWORD dwActiveProtocol;
    LONG result;
    // Ustawienie kodowania konsoli na UTF-8
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    // Inicjalizacja kontekstu
    result = SCardEstablishContext(SCARD_SCOPE_SYSTEM, NULL, NULL, &hContext);
    if (result = SCARD_S_SUCCESS) {
        cout << "Nie można zainicjować kontekstu karty." << endl;
        return -1;
    }

    // Pobieranie dostępnych czytników
    DWORD dwReaders;
    result = SCardListReaders(hContext, NULL, NULL, &dwReaders);
    if (result != SCARD_S_SUCCESS) {
        cout << "Nie można znaleźć czytników." << endl;
        SCardReleaseContext(hContext);
        return -1;
    }

    LPTSTR mszReaders = (LPTSTR)malloc(dwReaders * sizeof(char));
    result = SCardListReaders(hContext, NULL, mszReaders, &dwReaders);
    if (result != SCARD_S_SUCCESS) {
        cout << "Nie można znaleźć czytników." << endl;
        SCardReleaseContext(hContext);
        free(mszReaders);
        return -1;
    }

    // Wyświetlanie dostępnych czytników
    vector<string> readers;
    LPTSTR reader = mszReaders;
    while (*reader != '\0') {
        readers.push_back(reader);
        reader += strlen(reader) + 1;
    }

    cout << "Dostępne czytniki:" << endl;
    for (size_t i = 0; i < readers.size(); i++) {
        cout << i + 1 << ". " << readers[i] << endl;
    }

    // Wybór czytnika
    int readerChoice;
    cout << "Wybierz czytnik: ";
    cin >> readerChoice;
    if (readerChoice < 1 || readerChoice > readers.size()) {
        cout << "Nieprawidłowy wybór." << endl;
        return -1;
    }
//ScardStatus


    char szReaderName[256];
    DWORD dwReaderNameLen = sizeof(szReaderName);
    BYTE pbAtr[36];
    DWORD dwAtrLen = sizeof(pbAtr);
    DWORD dwState, dwProtocol;

    result = SCardStatus(hCard, szReaderName, &dwReaderNameLen, &dwState, &dwProtocol, pbAtr, &dwAtrLen);
    if (result == SCARD_S_SUCCESS) {
        cout << "Stan czytnika: " << dwState << endl;
    } else {
        cout << "Nie można uzyskać statusu karty: " << result << endl;
    }

    // Połączenie z wybranym czytnikiem
    result = SCardConnect(hContext, readers[readerChoice - 1].c_str(), SCARD_SHARE_SHARED,
                          SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1, &hCard, &dwActiveProtocol);
    if (result != SCARD_S_SUCCESS) {
        cout << "Nie można połączyć się z kartą." << endl;
        SCardReleaseContext(hContext);
        return -1;
    }

    cout << "Połączono z kartą." << endl;

    // Menu
    bool runMenu = true;
    while (runMenu) {
        cout << endl << "Menu:" << endl;
        cout << "1. Wyślij komendę HEX" << endl;
        cout << "2. Odczytaj kontakty (książkę telefoniczną)" << endl;
        cout << "3. Odczytaj SMSy" << endl;
        cout << "0. Wyjście" << endl;
        int choice;
        cin >> choice;

        switch (choice) {
            case 1: {
                string hexCommand;
                cout << "Podaj komendę HEX (bez spacji): ";
                cin >> hexCommand;

                // Konwersja ciągu znaków HEX na bajty
                vector<BYTE> command(hexCommand.length() / 2);
                for (size_t i = 0; i < hexCommand.length(); i += 2) {
                    command[i / 2] = (BYTE)strtol(hexCommand.substr(i, 2).c_str(), NULL, 16);
                }

                // Wysłanie komendy
                sendCommand(hCard, command.data(), command.size());
                break;
            }
            case 2: {
                // Przykładowe komendy do odczytu książki telefonicznej (można zmienić na właściwe)
                BYTE selectPhonebook[] = { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3A };
                sendCommand(hCard, selectPhonebook, sizeof(selectPhonebook));

                BYTE readPhonebook[] = { 0xA0, 0xB2, 0x01, 0x04, 0x00 };  // Odczyt pierwszego rekordu
                sendCommand(hCard, readPhonebook, sizeof(readPhonebook));
                break;
            }
            case 3: {
                // Przykładowe komendy do odczytu SMS-ów (można zmienić na właściwe)
                BYTE selectSMS[] = { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6F, 0x3C };
                sendCommand(hCard, selectSMS, sizeof(selectSMS));

                BYTE readSMS[] = { 0xA0, 0xB2, 0x01, 0x04, 0x00 };  // Odczyt pierwszego SMS-a
                sendCommand(hCard, readSMS, sizeof(readSMS));
                break;
            }
            case 0:
                runMenu = false;
                break;
            default:
                cout << "Nieprawidłowy wybór." << endl;
        }
    }

    // Zakończenie połączenia
    SCardDisconnect(hCard, SCARD_UNPOWER_CARD);
    SCardReleaseContext(hContext);
    free(mszReaders);

    return 0;
}
