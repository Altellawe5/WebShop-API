import { useEffect, useState } from "react";
import bodyCSS from "./body.module.css";
import ProductContainer from "./ProductContainer";
import Axios from "axios";
import { useNavigate } from "react-router-dom";

const Body = () => {

    // search bar
    const navigate = useNavigate();
    const [searchTerm, setSearchTerm] = useState("");

    const handleInputChange = (event) => {
        setSearchTerm(event.target.value);
    };

    const handleClick = () => {
        navigate(`search/${searchTerm}`);
        setSearchTerm("");
    };

    const handleKeyDown = (event) => {
        if (event.key === "Enter") {
            navigate(`search/${searchTerm}`);
            setSearchTerm("");
        }
    };



    // products from api
    const [producten, setProducten] = useState([]);
    useEffect(() => {
        const fetchProducten = async () => {
            try {
                const response = await Axios.get("https://localhost:7127/api/Products");
                setProducten(response.data);
            } catch (error) {
                console.log(error);
            }
        };

        fetchProducten();
    }, []);
    return (
        <body className={bodyCSS.body}>
            <div className={bodyCSS.searchDiv}>
                <input placeholder="Vul hier je zoekterm in (bv. tomaten)" type="text"
                    id="searchInput" name="searchInput" onChange={handleInputChange}
                    onKeyDown={handleKeyDown}
                    value={searchTerm}
                    className={bodyCSS.searchInput} />
                <button className={bodyCSS.searchButton} onClick={() => handleClick()}>
                    <svg xmlns='http://www.w3.org/2000/svg' width='20px' height='21px' viewBox='0 0 20 21'><g transform='translate(-2, -1)'><path d='M10.1249806,1.50004172 C11.6093521,1.50004172 12.9700257,1.86462399 14.2070021,2.59378912 C15.4439786,3.32295424 16.4270487,4.30602442 17.1562139,5.54300083 C17.885379,6.77997725 18.2499613,8.14065089 18.2499613,9.62502235 C18.2499613,10.6146031 18.0741804,11.5651221 17.7226188,12.4765781 C17.3710571,13.388034 16.882777,14.2083446 16.2577785,14.9375097 L16.8046522,14.9375097 C16.93486,14.9375097 17.0390266,14.9765721 17.1171515,15.0546969 L21.8827651,19.8203105 C21.9608899,19.8984354 21.9999523,20.002602 21.9999523,20.1328098 C21.9999523,20.2630176 21.9608899,20.3802048 21.8827651,20.4843715 L20.9843297,21.3437444 C20.8801631,21.447911 20.7629759,21.499994 20.6327681,21.499994 C20.5025603,21.499994 20.3983936,21.447911 20.3202688,21.3437444 L15.5546552,16.6171932 C15.4765304,16.5130266 15.437468,16.4088605 15.437468,16.3046939 L15.437468,15.7578202 C14.7083028,16.3828187 13.8879923,16.8710988 12.9765363,17.2226605 C12.0650804,17.5742221 11.1145614,17.750003 10.1249806,17.750003 C8.64060917,17.750003 7.27993553,17.3854207 6.04295911,16.6562556 C4.80598269,15.9270905 3.82291252,14.9440203 3.09374739,13.7070439 C2.36458227,12.4700675 2,11.1093938 2,9.62502235 C2,8.14065089 2.36458227,6.77997725 3.09374739,5.54300083 C3.82291252,4.30602442 4.80598269,3.32295424 6.04295911,2.59378912 C7.27993553,1.86462399 8.64060917,1.50004172 10.1249806,1.50004172 Z M10.1249806,3.37503725 C9.00519143,3.37503725 7.96352765,3.6549847 6.99998808,4.214879 C6.03644851,4.7747733 5.27473158,5.53649023 4.71483728,6.5000298 C4.15494298,7.46356937 3.87499553,8.50523316 3.87499553,9.62502235 C3.87499553,10.7448115 4.15494298,11.7864753 4.71483728,12.7500149 C5.27473158,13.7135545 6.03644851,14.4752714 6.99998808,15.0351657 C7.96352765,15.59506 9.00519143,15.8750075 10.1249806,15.8750075 C11.2447698,15.8750075 12.2864336,15.59506 13.2499732,15.0351657 C14.2135127,14.4752714 14.9752297,13.7135545 15.535124,12.7500149 C16.0950183,11.7864753 16.3749657,10.7448115 16.3749657,9.62502235 C16.3749657,8.50523316 16.0950183,7.46356937 15.535124,6.5000298 C14.9752297,5.53649023 14.2135127,4.7747733 13.2499732,4.214879 C12.2864336,3.6549847 11.2447698,3.37503725 10.1249806,3.37503725 Z' fill='#fff' /></g></svg>
                </button>
            </div>
            <ProductContainer producten={producten} categorie={"Producten"} />
        </body>
    );
};

export default Body;