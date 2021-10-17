#include <iostream>
#include <list>

using namespace std;

class Instrument {
public:

    int InstrumentID; // 1 - 5
    int price;
    bool isRegistered;

    Instrument() {
        InstrumentID = 0;
        price = 0;
        isRegistered = 0;
    }

    Instrument(int id, int p) {
        InstrumentID = id;
        price = p;
    }

    void Register() {
        isRegistered = 1;
    };

    void unregister() {
        isRegistered = 0;
    }

};

class Client {
public:

    string Name;
    int owned[5] = { 0,0,0,0,0 };

    Client(string a) {
        Name = a;
    }

    void buyInstrument(int id, ManagementSystem system) {
        if (system.instruments[id - 1].isRegistered) {
            owned[id - 1]++;
        }
        else cout << "Not registered" << endl;
    }
    void sellInstrument(int id) {
        if (owned[id - 1] > 0) {
            owned[id - 1]--;
        }
        else cout << "No more owned" << endl;
    }

};

class ManagementSystem {
public:

    list<Client> clients;
    list<Client>::iterator it;
    int clientAmount = 0;
    Instrument* instruments = new Instrument[5];

    ManagementSystem() {
        instruments[0] = Instrument(1, 100);
        instruments[1] = Instrument(2, 200);
        instruments[2] = Instrument(3, 300);
        instruments[3] = Instrument(4, 400);
        instruments[4] = Instrument(5, 500);

    }

    void addClient(string name) {
        clients.push_front(Client(name));
        clientAmount++;
    }
    void removeClient(string name) {
        for (it = clients.begin(); it != clients.end(); it++)
            if (it->Name == name) clients.remove(it->Name);
    }
    void printClientsInstruments() {
        for (it = clients.begin(); it != clients.end(); it++) {
            cout << it->Name << endl;
            for (int i = 0; i < 5; i++) {
                if (it->owned[i] >= 1) cout << instruments[i].InstrumentID << " " << instruments[i].price << endl;
            }
        }
    };
};

class API {
    ManagementSystem system = ManagementSystem();
    
public:

    void addClient() {
        string name;
        cin >> name;
        system.addClient(name);
    }

    void removeClient() {
        string name;
        cin >> name;
        system.removeClient(name);
    }

    void printClientsInstruments() {
        system.printClientsInstruments();
    }

    void registerInstrument() {
        int id;
        cin >> id;
        system.instruments[id - 1].Register();
    }

    void unregisterInstrument() {
        int id;
        cin >> id;
        system.instruments[id - 1].unregister();
    }

    void buyInstrument(string name, int id) {
        system.it = system.clients.begin();
        while (system.it->Name != name) system.it++;
        system.it->buyInstrument(id, system);
    }

    void sellInstrument(string name, int id){
        system.it = system.clients.begin();
        while (system.it->Name != name) system.it++;
        system.it->sellInstrument(id);
    }
};

int main()
{
    cout << "Hello world!" << endl;
    return 0;
}
