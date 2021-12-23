package wgn.workshare.fornecedores.models;

import org.apache.tomcat.jni.Local;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.UUID;

public class Fornecedor {
    private String nome;
    private LocalDateTime dataNascimento;
    private LocalDateTime dataCadastro;
    private UUID id;

    public Fornecedor(String nome, LocalDateTime dataNascimento){
        this.nome = nome;
        this.dataNascimento = dataNascimento;
        this.dataCadastro = LocalDateTime.now();
        this.id = UUID.randomUUID();
    }

    public LocalDateTime getDataNascimento(){
        return this.dataNascimento;
    }

    public String getNome(){
        return this.nome;
    }

    public UUID getId(){
        return this.id;
    }


}
