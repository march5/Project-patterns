#include <iostream>
#include <vector>

class Multimedia{

public:
    virtual Multimedia* clone() = 0;

    virtual void toString() = 0;
};

class Picture : public Multimedia {

    std::string name = "deafault1";
    std::string type = "Picture";

    Picture* clone() {
        Picture* n = new Picture;
        n->name = this->name;
        n->type = this->type;

        return n;
    }

    void toString() {
        std::cout << this->name << " " << this->type << std::endl;
    }

};

class Music : public Multimedia {
    std::string name = "deafault2";
    std::string type = "Music";

    Music* clone() {
        Music* n = new Music;
        n->name = this->name;
        n->type = this->type;

        return n;
    }

    void toString() {
        std::cout << this->name << " " << this->type << std::endl;
    }
};

class Movie : public Multimedia {
    std::string name = "deafault3";
    std::string type = "Movie";

    Movie* clone() {
        Movie* n = new Movie;
        n->name = this->name;
        n->type = this->type;

        return n;
    }

    void toString() {
        std::cout << this->name << " " << this->type << std::endl;
    }
};

int main()
{
    std::vector<Multimedia*> my_multimedia;
    my_multimedia.push_back(new Picture);
    my_multimedia.push_back(new Music);
    my_multimedia.push_back(new Movie);
    std::vector<Multimedia*> multimedia_copy;
    for (std::vector<Multimedia*>::iterator it = my_multimedia.begin();
        it != my_multimedia.end();
        ++it)
    {
        multimedia_copy.push_back((*it)->clone());
    }
    for (std::vector<Multimedia*>::iterator it2 = my_multimedia.begin();
        it2 != my_multimedia.end();
        ++it2)
    {
        (*it2)->toString();
    }
    return 0;
}