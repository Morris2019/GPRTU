namespace GPRTU;
using System.Collections.ObjectModel;
using GPRTU.Models;
using GPRTU.ViewModels;
using The49.Maui.BottomSheet;

public partial class LocationSheet : BottomSheet
{
    public ObservableCollection<Pickuploc> MyItems { get; set; }

    private readonly List<Pickuploc> PicupItemSource = new()
    {
     
        new Pickuploc
        {
            StationName = "Kwame Nkromah Circle Bus Terminals",
            Destinations = "Kukurantumi, Kwabeng, Kwahu Asafo, Kwahu Nsaba, Larteh Akuapem, Manhyia, Mpraeso, Mpraeso Amanfrom, New Abirem, Nkawkaw, Nkwatia Kwahu, Nsawam, Nuaso, Obo Kwahu, Oboo, Ghana, Obosomase Akuapem, Old Tafo, Oseim, Osino, Otumi, Pakro, Pampanso, Peduase, Pepease, Pokrom, Senchi , Somanya, Suhum, Topremang, Wa, Tumu, Funsi, Lawra, Gwolu, Nadowli, Jirapa, Lambusie, Nandom, Wechiau, Hamile, Pudo, Charia, Kaleo, Zambo, Eremon, Zebilla, Tongo, Paga, Garu, Bolgatanga, Bawku, Sandema, image of Navrongo, Navrongo, Binaba, Zuarungu, Bongo, Dabila, Wiaga, Gbeogo, Kulungugu, Worikambo, Kpandai, Savelugu, Karaga, Yendi, Saboba, Tamale, Gushiegu, Bimbila, Zabzugu, Tatale, Wulensi, Kumbungu, Tolon, Nyankpala, Lungni, Paga, Larabanga, Daboya, Buipe, Wulugu, Bole, Sheini, Kpabia, Salaga, Damongo, Tongo, Sumni, boma, Chereponi, Bamboi, Nakpanduri, Nalerigu, Sawla, Yagaba, Derma, Berekum(includes kato), Nkrankwanta, Kintampo, Kwame Danso, Kajaji, Yeji, Prang, Amanten, Atebubu, Busunya, Nkoranza, Dromankese, Sankore, Kukuom, Kenyase, Hwidiem Acherensua, Mim, Techimantia, Bechem, Duayaw Nkwanta, Banda, Ahenkro, Dormaa Ahenkro Wamfie,Drobo,Sampa Nsawkaw Wenchi, Jema Tuobodom Nsoatre, Chiraa Odumase, Sunyani (includes Fiapre, Abesim, New Dormaa), Techiman( includes nkwaeso, Krobo, Hansua),Goaso, Abease, Jinijini, Babatokuma, Suma, Ahenkro,Ofuman ",
            BusTerminals = "VIP, O.A, STC, EXPRESS, METRO MASS, NEOPLAN GPRTU",
            TransVendors = "VIP, O.A, STC, EXPRESS, METRO MASS, GPRTU Buss, Mini Buses",
            latitude = 5.57119,
            longitude = -0.21972,
        },
        new Pickuploc
        {
            StationName = "Accra Central Terminals",
            Destinations = "Abor, Abutia Kpota, Abutia-Teti, Adafienu, Adaklu, Adaklu Waya, Adidome, Aflao, Agbozume, Agortime-Kpetoe, Akatsi, Akome, Akpafu, Akrofu, Alakple, Alavanyo, Amedzofe, Anfoega, Anlo Afiadenyigba, Anloga, Anyako, Anyanui, Asukawkaw, Atiavi, Atimpoko, Ave-Dakpa, Aveyime-Battor, Baglo, Bame, Brewaniase, Dabala, Dafor, Denu, Dzelukope, Dzodze, Dzolokpuita, Gbefi, Gbledi-Agbogame, Hatsukope, Have, Ghana, Hedzranawo, Hlefi, Ho, Hohoe, Juapong, Keta, Klefe, Klikor, Kpale Kpalime, Kpalime Duga, Kpando, Kpedze, Kpeme, Kpetoe, Kpeve, Leklebi, Logba Adzekoe, Lolobi, Mafi-Kumasi, Mepe, Nogokpo, Peki, Podoe, Seva, Shia, Sogakope, Sokpoe, Tadzewu, Tanyigbe, Taviefe, Tegbi, Kpalime, Tokor, Tongor Kaira, Tsito, Vakpo, Vane, Avatime, Ve Golokwati, Ve-Koloenu, Vume, Kukurantumi, Kwabeng, Kwahu Asafo, Kwahu Nsaba, Larteh Akuapem, Manhyia, Mpraeso, Mpraeso Amanfrom, New Abirem, Nkawkaw, Nkwatia Kwahu, Nsawam, Nuaso, Obo Kwahu, Oboo, Ghana, Obosomase Akuapem, Old Tafo, Oseim, Osino, Otumi, Pakro, Pampanso, Peduase, Pepease, Pokrom, Senchi , Somanya, Suhum, Topremang",
            BusTerminals = "Tema Station, Tudu Station, C.M.B Station",
            TransVendors = "VIP, O.A, STC, EXPRESS, METRO MASS, GPRTU Buss, Mini Buses",
            latitude = 5.549588,
            longitude = -0.206981,
        },
        new Pickuploc
        {
            StationName = "Agbogbloshe Bus Terminal",
            Destinations = "Wa, Tumu, Funsi, Lawra, Gwolu, Nadowli, Jirapa, Lambusie, Nandom, Wechiau, Hamile, Pudo, Charia, Kaleo, Zambo, Eremon, Zebilla, Tongo, Paga, Garu, Bolgatanga, Bawku, Sandema, image of Navrongo, Navrongo, Binaba, Zuarungu, Bongo, Dabila, Wiaga, Gbeogo, Kulungugu, Worikambo, Kpandai, Savelugu, Karaga, Yendi, Saboba, Tamale, Gushiegu, Bimbila, Zabzugu, Tatale, Wulensi, Kumbungu, Tolon, Nyankpala, Lungni, Paga, Larabanga, Daboya, Buipe, Wulugu, Bole, Sheini, Kpabia, Salaga, Damongo, Tongo, Sumni, boma, Chereponi, Bamboi, Nakpanduri, Nalerigu, Sawla, Yagaba , Derma, Berekum(includes kato), Nkrankwanta, Kintampo, Kwame Danso, Kajaji, Yeji, Prang, Amanten, Atebubu, Busunya, Nkoranza, Dromankese, Sankore, Kukuom, Kenyase, Hwidiem Acherensua, Mim, Techimantia, Bechem, Duayaw Nkwanta, Banda, Ahenkro, Dormaa Ahenkro Wamfie,Drobo,Sampa Nsawkaw Wenchi, Jema Tuobodom Nsoatre, Chiraa Odumase, Sunyani (includes Fiapre, Abesim, New Dormaa), Techiman ( includes nkwaeso, Krobo, Hansua),Goaso, Abease, Jinijini, Babatokuma, Suma, Ahenkro,Ofuman, Kukurantumi, Kwabeng, Kwahu Asafo, Kwahu Nsaba, Larteh Akuapem, Manhyia, Mpraeso, Mpraeso Amanfrom, New Abirem, Nkawkaw, Nkwatia Kwahu, Nsawam, Nuaso, Obo Kwahu, Oboo, Ghana, Obosomase Akuapem, Old Tafo, Oseim, Osino, Otumi, Pakro, Pampanso, Peduase, Pepease, Pokrom, Senchi , Somanya, Suhum, Topremang",
            BusTerminals = "VIP, Metro Bus, STC, Express, OA, VVIP,Mini Buses",
            TransVendors = "VIP, O.A, STC, EXPRESS, METRO MASS, GPRTU Buss, Mini Buses",
            latitude = 5.551973,
            longitude = -0.222139,
        },
        new Pickuploc
        {
            StationName = "Kaneshe Bus Terminal",
            Destinations = "Agona Swedru, Asin Foso, Saltpond, Dunkwa Offin, Apam, Cape Coast, Winneba, Twifo Praso Kasoa, Awutu Breku, Abura, Dunkwa Diaso, Nsaba, Assin Kyekyewere, Afrance, Ajumako, Mankessim, Nsuta Potsin, Cape Coast  Nyakrom Asikuma Esakyir Obrachere Kwanyako , Kukurantumi, Kwabeng, Kwahu Asafo, Kwahu Nsaba, Larteh Akuapem, Manhyia, Mpraeso, Mpraeso Amanfrom, New Abirem, Nkawkaw, Nkwatia Kwahu, Nsawam, Nuaso, Obo Kwahu, Oboo, Ghana, Obosomase Akuapem, Old Tafo, Oseim, Osino, Otumi, Pakro, Pampanso, Peduase, Pepease, Pokrom, Senchi , Somanya, Suhum, Topremang, Aboadze, Aboso, Adiembra, Adubrim, Adum Banso, Airport Ridge, Akotom, Anaji, Apowa, Apremodo, Asankragua, Asasetre, Atuabo, Awaso, Axim, Benchema-Nkatieso, Bogoso, Botumagyabu, Daboase, Diabene, Effia, Effiakuma, Eikwe, Ellembelle, Essiama, Essikado, Fijai, Huni Valley, Inchaban, Juabo, Ketan, Kojokrom, Kwawkrom, Kwesimintsim, Ghana, Manso, Mpintsin, Mpohor, Nkroful, Nsein, Nzulezo, Old Subri, Omanpe, Prestea, Samreboi, Sefwi-Bekwai, Sekondi,  Shama, Tanokrom, Takoradi, Tarkwa, Tikobo No. 1, Wassa-Akropong, Windy Ridge, Takoradi",
            BusTerminals = "VIP, Metro Bus, STC, Express, OA, VVIP,Mini Buses",
            TransVendors = "VIP, O.A, STC, EXPRESS, METRO MASS, GPRTU Buss, Mini Buses",
            latitude = 5.569596,
            longitude = -0.217399,
        },
        new Pickuploc
        {
            StationName = "Madina Bus Terminal",
            Destinations = "Abor, Abutia Kpota, Abutia-Teti, Adafienu, Adaklu, Adaklu Waya, Adidome, Aflao, Agbozume, Agortime-Kpetoe, Akatsi, Akome, Akpafu, Akrofu, Alakple, Alavanyo, Amedzofe, Anfoega, Anlo Afiadenyigba, Anloga, Anyako, Anyanui, Asukawkaw, Atiavi, Atimpoko, Ave-Dakpa, Aveyime-Battor, Baglo, Bame, Brewaniase, Dabala, Dafor, Denu, Dzelukope, Dzodze, Dzolokpuita, Gbefi, Gbledi-Agbogame, Hatsukope, Have, Ghana, Hedzranawo, Hlefi, Ho, Hohoe, Juapong, Keta, Klefe, Klikor, Kpale Kpalime, Kpalime Duga, Kpando, Kpedze, Kpeme, Kpetoe, Kpeve, Leklebi, Logba Adzekoe, Lolobi, Mafi-Kumasi, Mepe, Nogokpo, Peki, Podoe, Seva, Shia, Sogakope, Sokpoe, Tadzewu, Tanyigbe, Taviefe, Tegbi, Kpalime, Tokor, Tongor Kaira, Tsito, Vakpo, Vane, Avatime, Ve Golokwati, Ve-Koloenu, Vume, Kukurantumi, Kwabeng, Larteh Akuapem , Nkawkaw, Nsawam, Obosomase Akuapem, Old Tafo, Peduase, Somanya, Suhum",
            BusTerminals = "Marina market center, Zongo Junction ",
            TransVendors = "VIP, Metro Bus, STC, Express, OA, VVIP,Mini Buses",
            latitude = 5.718790,
            longitude = -0.172281,
        },
        new Pickuploc
        {
            StationName = "Achimota Bus Terminal",
            Destinations = "Kukurantumi, Kwabeng, Kwahu Asafo, Kwahu Nsaba, Larteh Akuapem, Manhyia, Mpraeso, Mpraeso Amanfrom, New Abirem, Nkawkaw, Nkwatia Kwahu, Nsawam, Nuaso, Obo Kwahu, Oboo, Ghana, Obosomase Akuapem, Old Tafo, Oseim, Osino, Otumi, Pakro, Pampanso, Peduase, Pepease, Pokrom, Senchi , Somanya, Suhum, Topremang, Derma, Berekum(includes kato), Nkrankwanta, Kintampo, Kwame Danso, Kajaji, Yeji, Prang, Amanten, Atebubu, Busunya, Nkoranza, Dromankese, Sankore, Kukuom, Kenyase, Hwidiem Acherensua, Mim, Techimantia, Bechem, Duayaw Nkwanta, Banda, Ahenkro, Dormaa Ahenkro Wamfie,Drobo,Sampa Nsawkaw Wenchi, Jema Tuobodom Nsoatre, Chiraa Odumase, Sunyani (includes Fiapre, Abesim, New Dormaa), Techiman( includes nkwaeso, Krobo, Hansua),Goaso, Abease, Jinijini, Babatokuma, Suma, Ahenkro,Ofuman, Kukurantumi, Kwabeng, Kwahu Asafo, Kwahu Nsaba, Larteh Akuapem, Manhyia, Mpraeso, Mpraeso Amanfrom, New Abirem, Nkawkaw, Nkwatia Kwahu, Nsawam, Nuaso, Obo Kwahu, Oboo, Ghana, Obosomase Akuapem, Old Tafo, Oseim, Osino, Otumi, Pakro, Pampanso, Peduase, Pepease, Pokrom, Senchi , Somanya, Suhum, Topremang",
            BusTerminals = "Pokuase, Amasaman, Achimota",
            TransVendors = "VIP, O.A, STC, EXPRESS, METRO MASS, GPRTU Buss, Mini Buses",
            latitude = 5.629767,
            longitude = -0.240113,
        }
    };

    public LocationSheet()
    {
        InitializeComponent();
        //BindingContext = viewModel;
        MyItems = new ObservableCollection<Pickuploc>(PicupItemSource);
        
      
         BindingContext = this;
    }

    async void LocationSelected(object sender, SelectionChangedEventArgs e)
    {
        var piclocation = e.CurrentSelection.FirstOrDefault() as Pickuploc;

        if (piclocation == null)
            return;

        await Shell.Current.GoToAsync(state: $"//MainPage?MainPage={piclocation.latitude},{piclocation.longitude}");


       // if (piclocation == null)
        //{
          //  return;
        //}
        //else
        //{
          //  await Application.Current.MainPage.DisplayAlert($"Data Error", piclocation.longitude.ToString(), "OK");

            // await Shell.Current.GoToAsync($"//{nameof(MainPage)}?Content={piclocation.longitude.ToString()},{piclocation.latitude.ToString()}");
       // }
    }

    void SearchDest(object sender, TextChangedEventArgs e)
    {
        var searchTerm = e.NewTextValue;

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = string.Empty;
        }

        // searchTerm = searchTerm.ToLowerInvariant();
       
        var filteredItems = PicupItemSource.Where(found => found.Destinations.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())).ToList();

        foreach (var value in PicupItemSource)
        {
            if (!filteredItems.Contains(value))
            {
                MyItems.Remove(value);
            }
            else if (!MyItems.Contains(value))
            {
                MyItems.Add(value);
            }
        }
    }
}