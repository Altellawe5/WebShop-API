// import { Container , Row } from "react-bootstrap";
import Style from "./Footer.module.css";

const Footer = () => {
    return (
        <footer className={Style.footer}>
            <div className={Style.logoDiv}>
                <a href="https://colruytgroup.com/wps/portal/cg/nl/home" target="">
                    <img className={Style.logo} src="../Images/logo--colruytgroup.svg" alt="" />
                </a>
            </div>
            <div classame={Style.listDiv}>
                <ul className={Style.footerLinks}>
                    <li>
                        <span>
                            © Colruyt Group
                            <span id="subfooterYear">2023</span>
                            <script type="text/javascript">
                                document.getElementById('subfooterYear').innerText = new Date().getFullYear().toString();
                            </script>
                        </span>
                    </li>
                    <li>
                        <a href="https://xtra.colruytgroup.be/xtra/nl/privacyverklaring" target="">
                            Privacyverklaring XTRA
                        </a>
                    </li>
                    <li>
                        <a href="/nl/privacyverklaring-facturatie-particulieren">
                            Privacyverklaring  facturatie particulieren
                        </a>
                    </li>
                    <li>
                        <a href="https://www.mijnxtra.be/algemene-voorwaarden.html" target="">
                            Algemene voorwaarden XTRA
                        </a>
                    </li>
                    <li>
                        <a href="/nl/cookiebeleid">
                            Cookiebeleid
                        </a>
                    </li>
                    <li>
                        <a href="/nl">
                            Colruyt Laagste Prijzen - Edingensesteenweg 196, Halle
                        </a>
                    </li>
                    <li>
                        <a href="/nl">
                            +32 2 363 55 45 - info@colruyt.be
                        </a>
                    </li>
                    <li>
                        <a href="/nl">
                            KBO: 0400.378.485 - BTW: BE-0400.378.485
                        </a>
                    </li>
                    <li>
                        <span id="ot-sdk-btn" className="ot-sdk-show-settings">Cookie-instellingen </span>
                    </li>
                </ul>
            </div>
        </footer>
    );
};

export default Footer;