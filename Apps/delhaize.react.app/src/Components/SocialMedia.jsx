import React from "react";
import Style from "./SocialMedia.module.css";

const SocialMedia = () => {
  return (
    <ul className={Style.list}>
      <li className={Style.listItem}>
        <a href="https://www.facebook.com/Delhaize">
          <img
            src="//static.delhaize.be/site/binaries/_ht_1652277600000/content/gallery/footer/social-link/facebook.svg"
            alt="Facebook"
            loading="lazy"
          ></img>
        </a>
      </li>
      <li className={Style.listItem}>
        <a href="https://www.instagram.com/delhaizebelgium/">
          <img
            src="//static.delhaize.be/site/binaries/_ht_1652277600000/content/gallery/footer/social-link/instagram.svg"
            alt="Instagram"
            loading="lazy"
          ></img>
        </a>
      </li>
      <li className={Style.listItem}>
        <a href="https://www.youtube.com/user/delhaizebelgium">
          <img
            src="//static.delhaize.be/site/binaries/_ht_1652277600000/content/gallery/footer/social-link/youtube.svg"
            alt="Youtube"
            loading="lazy"
          ></img>
        </a>
      </li>
      <li className={Style.listItem}>
        <a href="https://www.linkedin.com/company/delhaize-belgium/mycompany/">
          <img
            src="//static.delhaize.be/site/binaries/_ht_1652277600000/content/gallery/footer/social-link/linkedin.svg"
            alt="LinkedIn"
            loading="lazy"
          ></img>
        </a>
      </li>
      <li className={Style.listItem}>
        <a href="https://www.pinterest.com/delhaizebelgium/_created/">
          <img
            src="//static.delhaize.be/site/binaries/_ht_1652277600000/content/gallery/footer/social-link/pinterest.svg"
            alt="Pinterest"
            loading="lazy"
          ></img>
        </a>
      </li>
    </ul>
  );
};

export default SocialMedia;
