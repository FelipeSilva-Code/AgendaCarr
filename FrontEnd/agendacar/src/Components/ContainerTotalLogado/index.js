import React from 'react';
import Menu from '../MenuLogado';
import Footer from '../Footer';
import './Styles.css'

export default function ContainerTotalLogado (props) {
    return(
        <>
            <Menu idUsuario={props.idUsuario} perfil={props.perfil}/>
                <div className="ContainerTotal">
                    {props.children}
                </div>
            <Footer/>

        </>
    )
}