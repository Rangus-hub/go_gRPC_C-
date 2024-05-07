package main

import (
	"context"
	"fmt"
	"log"
	pb "main/proto"
	"math/rand"
	"net"

	"google.golang.org/grpc"
)

type server struct {
	pb.UnimplementedPplManagementServer
}

const (
	port = ":8080"
)

// CreatePerson implements PplManagementServer.CreatePerson
func (s *server) CreatePerson(ctx context.Context, req *pb.PersonInfo) (*pb.Employee, error) {
	// Generate random ID and company name
	id := rand.Int31n(1000)       // Random ID between 0 and 999
	company := getRandomCompany() // Get a random company name

	// Create and return the Employee object
	employee := &pb.Employee{
		Id:      id,
		Company: company,
		Name:    req.Name,
		Email:   req.Email,
	}
	return employee, nil
}

// Function to get a random company name
func getRandomCompany() string {
	companies := []string{"Google", "Apple", "Microsoft", "Amazon", "Facebook"}
	return companies[rand.Intn(len(companies))]
}

func main() {

	lis, err := net.Listen("tcp", port)

	if err != nil {
		log.Fatal("Could not connect")
	}

	grpc_Server := grpc.NewServer()

	pb.RegisterPplManagementServer(grpc_Server, &server{})

	if err := grpc_Server.Serve(lis); err != nil {
		log.Fatalf("failed to serve: %v", err)
	}

	fmt.Println("Server running at " + port)
}
