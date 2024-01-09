import Logo from "./Logo";

const Footer = () => {
    const today = new Date();
    return(
        <div className="Footer">
              <Logo />
              <p>Copyright &copy; {today.getFullYear()}</p>
        </div>
    );
}

export default Footer;